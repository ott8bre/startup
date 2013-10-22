/*
 * Utente: Francesco
 * Data: 21/10/2013
 * Ora: 14:28
 */
using System;
using System.Collections.Generic;
using modules.actors;
using modules.messages;

namespace modules
{
	/// <summary>
	/// Description of Context.
	/// </summary>
	public class Context
	{
		private static Context ctx = new Context();
		
		private Queue<Message> queue = new Queue<Message>();
		
		private Dictionary<long, List<long>> map = new Dictionary<long, List<long>>();
		
		protected static bool Bind( Outgo o, Income i){
			if(!ctx.map.ContainsKey(o.Id)){
				ctx.map[o.Id] = new List<long>();
			}
			if(!ctx.map[o.Id].Contains(i.Id)){
				ctx.map[o.Id].Add(i.Id);
			}			
			return true;
		}
		
		public static bool Bind<O,I>( Outgo<O> o, Income<I> i){
			// Test if convertible
			return Bind((Outgo)o,(Income)i);
		}

		public static bool Bind( Outgo o, Trigger t){
			// Test if convertible
			return Bind((Outgo)o,(Income)t);
		}

		public static bool Bind( Signal s, Income i){
			// Test if convertible
			return Bind((Outgo)s,(Income)i);
		}
		
		public static bool Step()
		{
			Console.WriteLine(".");
			
			Queue<Message> queue = ctx.queue;
			ctx.queue = new Queue<Message>();
			
			int size = queue.Count;
			while(queue.Count>0){
				var m = queue.Dequeue();
				if(ctx.map.ContainsKey(m.SenderId)){
					Port p;
					foreach (var id in ctx.map[m.SenderId]) {
						p = Port.GetById(id);
						
						Console.WriteLine(m + " -> " + p);
						
						((Income)p).Recv(m);
					}
				}
			}
			return size>0;
		}
		
		public static void Enqueue(Port p, Message m)
		{
			ctx.queue.Enqueue(m);
			
			Console.WriteLine(p + " -> " + m);
		}
	}
}

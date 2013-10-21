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
		
		public static void Bind( Outgo o, Income i){
			if(!ctx.map.ContainsKey(o.Id)){
				ctx.map[o.Id] = new List<long>();
			}
			if(!ctx.map[o.Id].Contains(i.Id)){
				ctx.map[o.Id].Add(i.Id);
			}			
		}
		/*
		public static void Bind<T>( Outgo<T> o, Income<T> i){
			Bind((Outgo)o,(Income)i);
		}
		*/
		public static bool Step()
		{
			if(ctx.queue.Count>0){
				var m = ctx.queue.Dequeue();
				if(ctx.map.ContainsKey(m.SenderId)){
					foreach (var id in ctx.map[m.SenderId]) {
						((Income)Port.GetById(id)).Recv(m);
					}
				}
				return true;
			}
			return false;
		}
		
		public static void Enqueue(Message m)
		{
			ctx.queue.Enqueue(m);
		}
	}
}

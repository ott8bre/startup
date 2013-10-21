/*
 * Utente: Francesco
 * Data: 21/10/2013
 * Ora: 11:01
 */
using System;
using modules.actors;
using modules.messages;

namespace modules
{
	class Program
	{
		//static Context ctx = new Context();
		
		public static void Main(string[] args)
		{
			var m = new Message<string>(0, "Hello World!");

			Outgo<int> data = new Outgo<int>() ;
			data.Set(4);
			
			Prova a = new Prova();
			Prova b = new Prova();
			
			//--
			
			Print p = new Print();
			
			Signal start = new Signal();
			
			Context.Bind(start, a.bang);			
			
			Context.Bind(data, a.in_1);
			Context.Bind(data, a.in_2);
			Context.Bind(a.out_1, b.in_1);			
			Context.Bind(a.out_1, b.bang);
			Context.Bind(a.out_1, p.all);
			Context.Bind(a.out_1, p.bang);
			
			//Console.WriteLine(m);
			start.Set();			
			while (Context.Step()) {
				
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
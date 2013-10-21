/*
 * Utente: Francesco
 * Data: 21/10/2013
 * Ora: 13:25
 */
using System;
using modules.actors;

namespace modules
{
	/// <summary>
	/// Description of Prova.
	/// </summary>
	public class Prova
	{
		public Signal overflow = new Signal();

		public Income<int> in_1 = new Income<int>();
		public Income<int> in_2 = new Income<int>();
		
		public Outgo<int> out_1 = new Outgo<int>();
		
		public Trigger bang;

		public Prova()
		{
			bang = new Trigger( method );
		}
		
		protected void method(){
			try {
				out_1.Set( in_1.Get() * in_2.Get() );
			} catch (OverflowException) {
				overflow.Set();
			}
			
		}
	}
}

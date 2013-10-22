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
	public class Prova : Actor
	{
		public Signal overflow;

		public Income<int> in_1;
		public Income<int> in_2;
		
		public Outgo<int> out_1;
		
		public Trigger bang;

		public Prova()
		{
			overflow = new Signal(Id, "overflow");
			
			in_1 = new Income<int>(Id);
			in_2 = new Income<int>(Id);
			
			out_1 = new Outgo<int>(Id);
			
			bang = new Trigger( Id, method );
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

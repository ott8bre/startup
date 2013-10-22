/*
 * Utente: Francesco
 * Data: 21/10/2013
 * Ora: 16:18
 */
using System;
using modules.actors;

namespace modules
{
	/// <summary>
	/// Description of Print.
	/// </summary>
	public class Print : Actor
	{
		public Income<int> all;
		
		public Trigger bang;
		
		public Print()
		{
			all = new Income<int>(Id);
			this.bang = new Trigger(Id, () => {
			                        	Console.WriteLine(all.Get());
			                        });
		}
	}
}

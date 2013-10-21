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
	public class Print
	{
		public Income<int> all = new Income<int>();
		
		public Trigger bang;
		
		public Print()
		{
			this.bang = new Trigger( () => {
			                        	Console.WriteLine(all.Get());
			                        });
		}
	}
}

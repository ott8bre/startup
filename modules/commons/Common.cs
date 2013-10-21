/*
 * Utente: Francesco
 * Data: 21/10/2013
 * Ora: 12:14
 */
using System;

namespace modules.commons
{
	/// <summary>
	/// Description of Common.
	/// </summary>
	public abstract class Common
	{
		protected static long id_counter = 0;
		protected static long next_id() { return ++id_counter; }
		
		//--//
		
		protected long 			id 			= next_id();
		protected DateTime 		created 	= DateTime.Now; 
		
		public long 		Id 			{ get { return id; } }
		public DateTime 	Created 	{ get { return created; } }
	}
}

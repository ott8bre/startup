/*
 * Utente: Francesco
 * Data: 21/10/2013
 * Ora: 11:16
 */
using System;
using modules.commons;

namespace modules.messages
{
	/// <summary>
	/// Message: Abstraction for Data intechanges.
	/// </summary>
	public abstract class Message : Common
	{
		protected long 			senderId 	= 0;

		public long 		SenderId 	{ get { return senderId; } }
		
		public Message(long senderId)
		{
			this.senderId = senderId;
		}
		/*
		public override string ToString()
		{
			return string.Format("[Message SenderId={0}, Created={1}]", senderId, created);
		}
		*/
	}

	public class Message<ContentType> : Message //where Content : struct
	{ 
		protected ContentType 	content 	= default(ContentType);
		
		public ContentType 	Content 	{ get { return content; } }
		
		public Message(long senderId, ContentType content) : base(senderId)
		{
			this.content = content;
		}
		
		public override string ToString()
		{
			return string.Format("[M SenderId={0}, Created={1}, {2}={3}]", senderId, created.ToLongTimeString(), content.GetType().Name,content);
		}

	}
}

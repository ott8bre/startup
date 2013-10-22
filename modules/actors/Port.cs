/*
 * Utente: Francesco
 * Data: 21/10/2013
 * Ora: 12:26
 */
using System;
using System.Collections.Generic;

using modules.commons;
using modules.messages;

namespace modules.actors
{
	/// <summary>
	/// Port: Abstraction for Data routing.
	/// </summary>
	public abstract class Port : Common
	{
		private static Dictionary<long, Port> map = new Dictionary<long, Port>();
		public static Port GetById(long id) { return map[id]; }
		
		private long ownerId;
		
		private long OwnerId {get{ return ownerId; }}
		
		public Port(long owner)
		{
			this.ownerId = owner;
			map.Add(Id, this);
		}
		
		public override string ToString()
		{
			return string.Format("[P Id={0}, OwnerId={1}]", Id, OwnerId);
		}

	}
	
	public abstract class Income : Port
	{
		public abstract void Recv(Message m);
		
		public Income(long owner) : base(owner)
		{}
	}
	
	public class Trigger : Income {
		
		protected Action a = () => {};
		
		public Trigger(long owner, Action a) :base(owner)
		{
			this.a = a;
		}
		
		public override void Recv(Message m)
		{
			a();
		}
	}
	
	public class Income<ContentType> : Income
	{
		protected ContentType content = default(ContentType);
		
		public override void Recv(Message m)
		{
			content = ((Message<ContentType>)m).Content;
		}		
		
		public ContentType Get(){
			return content;
		}
		
		public Income(long owner) : base(owner)
		{}		
	}

	public abstract class Outgo : Port
	{
		protected void Send(Message m){
			Context.Enqueue(this, m);
		}

		public Outgo(long owner) : base(owner)
		{}
	}
	
	public class Signal : Outgo
	{
		public void Set(){
			Send(new Message<object>(Id, name));
		}	

		private string name;
		
		public Signal(long owner, string name) : base(owner)
		{
			this.name = name;
		}
	}
	
	public class Outgo<ContentType> : Outgo
	{
		protected ContentType content = default(ContentType);
		
		public void Set(ContentType content){
			this.content = content;
			Send(new Message<ContentType>(Id, content));
		}
		
		public Outgo(long owner) : base(owner)
		{}
	}
}

using System;
using System.Collections.Generic;

namespace CookieClicker.Runtime.Model
{
	public class DomainEvents
	{
		Dictionary<Type, List<Action<DomainEvent>>> domainEvents = new();

		public void SubscribeToDomainEvents<T>(Action<T> onDomainEvent) where T : DomainEvent {
			if (!domainEvents.TryGetValue(typeof(T), out List<Action<DomainEvent>> list))
				domainEvents[typeof(T)] = list = new List<Action<DomainEvent>>();
			list.Add(ev => onDomainEvent((T)ev));
		}

		public void RaiseDomainEvent<T>(T ev) where T : DomainEvent
		{
			if (!domainEvents.TryGetValue(typeof(T), out List<Action<DomainEvent>> events))
				return;
			foreach (Action<DomainEvent> domainEv in events)
				domainEv(ev);
		}
	}

	public interface DomainEvent {

	}

	public struct UnGotACookieEvent : DomainEvent
	{
		public int JarAmount;

		public UnGotACookieEvent(int jarAmount)
		{
			this.JarAmount = jarAmount;
		}
	}

	public struct GotACookieEvent : DomainEvent
	{
		public int JarAmount;

		public GotACookieEvent(int jarAmount)
		{
			this.JarAmount = jarAmount;
		}
	}
}

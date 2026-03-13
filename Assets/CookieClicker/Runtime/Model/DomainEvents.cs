using System;
using System.Collections.Generic;

namespace CookieClicker.Runtime.Model
{
	public class DomainEvents
	{
		static Dictionary<Type, List<Action<DomainEvent>>> domainEvents = new();

		public static void SubscribeToGotACookie(Action<GotACookieEvent> onGotACookie)
		{
			if (!domainEvents.TryGetValue(typeof(GotACookieEvent), out List<Action<DomainEvent>> list))
				domainEvents[typeof(GotACookieEvent)] = list = new List<Action<DomainEvent>>();
			list.Add(ev => onGotACookie((GotACookieEvent)ev));
		}

		public static void SubscribeToUngotACookie(Action<UnGotACookieEvent> onUngotACookie)
		{
			if (!domainEvents.TryGetValue(typeof(UnGotACookieEvent), out List<Action<DomainEvent>> list))
				domainEvents[typeof(UnGotACookieEvent)] = list = new List<Action<DomainEvent>>();
			list.Add(ev => onUngotACookie((UnGotACookieEvent)ev));
		}

		public static void RaiseGotACookie(GotACookieEvent ev)
		{
			if (!domainEvents.TryGetValue(typeof(GotACookieEvent), out List<Action<DomainEvent>> events))
				return;
			foreach (Action<DomainEvent> domainEv in events)
				domainEv(ev);
		}

		public static void RaiseUngotACookie(UnGotACookieEvent ev)
		{
			if (!domainEvents.TryGetValue(typeof(UnGotACookieEvent), out List<Action<DomainEvent>> events))
				return;
			foreach (Action<DomainEvent> domainEv in events)
				domainEv(ev);
		}

		public static void Reset()
		{
			domainEvents.Clear();
		}
	}

	public interface DomainEvent {

	}

	public struct UnGotACookieEvent : DomainEvent
	{
	}

	public struct GotACookieEvent : DomainEvent
	{

	}
}

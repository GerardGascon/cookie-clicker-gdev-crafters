using System;
using System.Collections.Generic;

namespace CookieClicker.Runtime.Model
{
	public class DomainEvents
	{
		static List<Action<UnGotACookieEvent>> UngotACookie = new List<Action<UnGotACookieEvent>>();

		static Dictionary<Type, List<Action<DomainEvent>>> domainEvents = new();

		public static void SubscribeToGotACookie(Action<GotACookieEvent> onGotACookie)
		{
			if (!domainEvents.TryGetValue(typeof(GotACookieEvent), out List<Action<DomainEvent>> list))
				domainEvents[typeof(GotACookieEvent)] = list = new List<Action<DomainEvent>>();
			list.Add(ev => onGotACookie((GotACookieEvent)ev));
		}

		public static void SubscribeToUngotACookie(Action<UnGotACookieEvent> onUngotACookie)
		{
			UngotACookie.Add(onUngotACookie);
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
			foreach (var action in UngotACookie) action(ev);
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

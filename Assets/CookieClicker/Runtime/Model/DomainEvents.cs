using System;
using System.Collections.Generic;

namespace CookieClicker.Runtime.Model
{
	public class DomainEvents
	{
		static List<Action<GotACookieEvent>> GotACookie = new List<Action<GotACookieEvent>>();
		static List<Action<UnGotACookieEvent>> UngotACookie = new List<Action<UnGotACookieEvent>>();

		// static List<Action<DomainEvent>> domainEvents = new();

		public static void SubscribeToGotACookie(Action<GotACookieEvent> onGotACookie)
		{
			GotACookie.Add(onGotACookie);
			// domainEvents.Add(ev => onGotACookie((GotACookieEvent)ev));
		}

		public static void SubscribeToUngotACookie(Action<UnGotACookieEvent> onUngotACookie)
		{
			UngotACookie.Add(onUngotACookie);
		}

		public static void RaiseGotACookie(GotACookieEvent ev)
		{
			foreach (var action in GotACookie) action(ev);
			// foreach (Action<GotACookieEvent> action in domainEvents.OfType<Action<GotACookieEvent>>()) {
			// 	action(ev);
			// }
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

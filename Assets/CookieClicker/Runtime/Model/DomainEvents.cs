using System;
using System.Collections.Generic;

namespace CookieClicker.Runtime.Model
{
	public class DomainEvents
	{
		static List<Action<GotACookieEvent>> GotACookie = new List<Action<GotACookieEvent>>();
		static List<Action<UnGotACookieEvent>> UngotACookie = new List<Action<UnGotACookieEvent>>();



		public static void SubscribeToGotACookie(Action<GotACookieEvent> onGotACookie)
		{
			GotACookie.Add(onGotACookie);
		}

		public static void SubscribeToUngotACookie(Action<UnGotACookieEvent> onUngotACookie)
		{
			UngotACookie.Add(onUngotACookie);
		}

		public static void RaiseGotACookie(GotACookieEvent ev)
		{
			foreach (var action in GotACookie) action(ev);
		}

		public static void RaiseUngotACookie(UnGotACookieEvent ev)
		{
			foreach (var action in UngotACookie) action(ev);
		}
	}

	public struct UnGotACookieEvent
	{
	}

	public struct GotACookieEvent
	{

	}
}

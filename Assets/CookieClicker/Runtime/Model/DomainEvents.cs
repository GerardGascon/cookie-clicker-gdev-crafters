using System;
using System.Collections.Generic;

namespace CookieClicker.Runtime.Model
{
	public class DomainEvents
	{
		static List<Action<GotACookieEvent>> GotACookie = new List<Action<GotACookieEvent>>();
		static Action<UnGotACookieEvent> UngotACookie;



		public static void SubscribeToGotACookie(Action<GotACookieEvent> onGotACookie)
		{
			GotACookie.Add(onGotACookie);
		}

		public static void SubscribeToUngotACookie(Action<UnGotACookieEvent> onUngotACookie)
		{
			UngotACookie += onUngotACookie;
		}

		public static void RaiseGotACookie(GotACookieEvent ev)
		{
			foreach (var action in GotACookie) action(ev);
		}

		public static void RaiseUngotACookie(UnGotACookieEvent ev)
		{
			UngotACookie?.Invoke(ev);
		}
	}

	public struct UnGotACookieEvent
	{
	}

	public struct GotACookieEvent
	{

	}
}

using System;

namespace CookieClicker.Runtime.Model
{
	public class DomainEvents
	{
		static Action<GotACookieEvent> GotACookie;
		static Action UngotACookie;

		public static void SubscribeToGotACookie(Action<GotACookieEvent> onGotACookie)
		{
			GotACookie += onGotACookie;
		}

		public static void SubscribeToUngotACookie(Action onUngotACookie)
		{
			UngotACookie += onUngotACookie;
		}

		public static void RaiseGotACookie(GotACookieEvent ev)
		{
			GotACookie?.Invoke(ev);
		}

		public static void RaiseUngotACookie()
		{
			UngotACookie?.Invoke();
		}
	}

	public struct GotACookieEvent
	{

	}
}

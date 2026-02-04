using System;

namespace CookieClicker.Runtime.Model
{
	public class DomainEvents
	{
		static Action<GotACookieEvent> GotACookie;
		static Action<UnGotACookieEvent> UngotACookie;

		public static void SubscribeToGotACookie(Action<GotACookieEvent> onGotACookie)
		{
			GotACookie += onGotACookie;
		}

		public static void SubscribeToUngotACookie(Action<UnGotACookieEvent> onUngotACookie)
		{
			UngotACookie += onUngotACookie;
		}

		public static void RaiseGotACookie(GotACookieEvent ev)
		{
			GotACookie?.Invoke(ev);
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

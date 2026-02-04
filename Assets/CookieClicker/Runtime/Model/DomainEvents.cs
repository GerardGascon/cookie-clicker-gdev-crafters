using System;

namespace CookieClicker.Runtime.Model
{
	public class DomainEvents
	{
		static Action GotACookie;
		public static Action UngotACookie;

		public static void SubscribeToGotACookie(Action onGotACookie)
		{
			GotACookie += onGotACookie;
		}

		public static void SubscribeToUngotACookie(Action onUngotACookie)
		{
			UngotACookie += onUngotACookie;
		}

		public static void RaiseGotACookie()
		{
			GotACookie?.Invoke();
		}
	}
}

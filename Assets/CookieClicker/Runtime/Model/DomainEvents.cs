using System;

namespace CookieClicker.Runtime.Model
{
	public class DomainEvents
	{
		public static Action GotACookie;
		public static Action UngotACookie;

		public static void SuscribeToGotACookie(Action onGotACookie)
		{
			GotACookie += onGotACookie;
		}
	}
}

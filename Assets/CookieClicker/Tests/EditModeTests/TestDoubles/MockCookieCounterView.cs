using CookieClicker.Runtime.Model;

namespace CookieClicker.Tests.EditModeTests.TestDoubles
{
	public class MockCookieCounterView
	{
		readonly Jar jar;

		public MockCookieCounterView(Jar jar)
		{
			this.jar = jar;
			DomainEvents.SubscribeToGotACookie(_ => Refresh());
			DomainEvents.SubscribeToUngotACookie(Refresh);
		}

		public int Counter { get; private set; }

		void Refresh() {
			Counter = jar.Amount;
		}
	}
}

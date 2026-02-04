using CookieClicker.Runtime.Model;

namespace CookieClicker.Tests.EditModeTests.TestDoubles
{
	public class MockCookieCounterView
	{
		readonly Jar jar;

		public MockCookieCounterView(Jar jar)
		{
			this.jar = jar;
			DomainEvents.SubscribeToGotACookie(Refresh);
			DomainEvents.SubscribeToUngotACookie(Refresh);
		}

		public int Counter { get; private set; }

		void Refresh() {
			Counter = jar.Amount;
		}

		void Refresh(GotACookieEvent gotACookieEvent)
		{
			Refresh();
		}
	}
}

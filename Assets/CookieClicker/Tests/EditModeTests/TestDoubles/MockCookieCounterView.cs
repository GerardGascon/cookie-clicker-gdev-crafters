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
			DomainEvents.UngotACookie += Refresh;
		}

		public int Counter { get; private set; }

		public void Refresh()
		{
			Counter = jar.Amount;
		}
	}
}

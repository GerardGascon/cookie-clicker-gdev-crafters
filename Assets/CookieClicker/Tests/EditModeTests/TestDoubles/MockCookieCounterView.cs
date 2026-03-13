using CookieClicker.Runtime.Model;

namespace CookieClicker.Tests.EditModeTests.TestDoubles
{
	public class MockCookieCounterView
	{
		readonly Jar jar;

		public MockCookieCounterView(Jar jar)
		{
			this.jar = jar;
			DomainEvents.SubscribeToDomainEvents<GotACookieEvent>(ev => Refresh(ev.JarAmount));
			DomainEvents.SubscribeToDomainEvents<UnGotACookieEvent>(ev => Refresh(jar.Amount));
		}

		public int Counter { get; private set; }

		void Refresh(int jarAmount) {
			Counter = jarAmount;
		}
	}
}

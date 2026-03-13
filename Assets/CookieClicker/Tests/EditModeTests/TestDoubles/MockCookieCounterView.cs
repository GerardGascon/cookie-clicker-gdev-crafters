using CookieClicker.Runtime.Model;

namespace CookieClicker.Tests.EditModeTests.TestDoubles
{
	public class MockCookieCounterView
	{
		public MockCookieCounterView()
		{
			DomainEvents.SubscribeToDomainEvents<GotACookieEvent>(ev => Refresh(ev.JarAmount));
			DomainEvents.SubscribeToDomainEvents<UnGotACookieEvent>(ev => Refresh(ev.JarAmount));
		}

		public int Counter { get; private set; }

		void Refresh(int jarAmount) {
			Counter = jarAmount;
		}
	}
}

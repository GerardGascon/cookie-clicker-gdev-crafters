using CookieClicker.Runtime.Model;

namespace CookieClicker.Tests.EditModeTests.TestDoubles
{
	public class MockCookieCounterView
	{
		public MockCookieCounterView(DomainEventBus domainEventBus)
		{
			domainEventBus.SubscribeToDomainEvents<GotACookieEvent>(ev => Refresh(ev.JarAmount));
			domainEventBus.SubscribeToDomainEvents<UnGotACookieEvent>(ev => Refresh(ev.JarAmount));
		}

		public int Counter { get; private set; }

		void Refresh(int jarAmount) {
			Counter = jarAmount;
		}
	}
}

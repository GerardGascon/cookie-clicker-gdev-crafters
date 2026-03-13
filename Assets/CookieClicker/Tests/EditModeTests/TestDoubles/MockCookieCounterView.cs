using CookieClicker.Runtime.Model;

namespace CookieClicker.Tests.EditModeTests.TestDoubles
{
	public class MockCookieCounterView
	{
		public MockCookieCounterView(DomainEvents domainEvents)
		{
			domainEvents.SubscribeToDomainEvents<GotACookieEvent>(ev => Refresh(ev.JarAmount));
			domainEvents.SubscribeToDomainEvents<UnGotACookieEvent>(ev => Refresh(ev.JarAmount));
		}

		public int Counter { get; private set; }

		void Refresh(int jarAmount) {
			Counter = jarAmount;
		}
	}
}

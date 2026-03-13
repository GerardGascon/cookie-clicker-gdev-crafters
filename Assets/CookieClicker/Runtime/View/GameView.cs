using CookieClicker.Runtime.Model;
using UnityEngine;

namespace CookieClicker.Runtime.View
{
	public class GameView : MonoBehaviour
	{
		Jar jar;

		public void Initialize(Jar jar, DomainEventBus domainEventBus)
		{
			this.jar = jar;
			Refresh(jar.Amount);
			domainEventBus.SubscribeToDomainEvents<GotACookieEvent>(ev => Refresh(ev.JarAmount));
			domainEventBus.SubscribeToDomainEvents<UnGotACookieEvent>(ev => Refresh(ev.JarAmount));
		}

		void Refresh(int jarAmount)
		{
			FindFirstObjectByType<CookieCounter>().Refresh(jarAmount);
			FindFirstObjectByType<PurchaseAutoclickerButton>().Refresh(jarAmount, jar.AutoclickerPrice);
		}
	}
}

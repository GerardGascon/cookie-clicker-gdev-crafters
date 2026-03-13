using CookieClicker.Runtime.Model;
using UnityEngine;

namespace CookieClicker.Runtime.View
{
	public class GameView : MonoBehaviour
	{
		Jar jar;

		public void Initialize(Jar jar, DomainEvents domainEvents)
		{
			this.jar = jar;
			Refresh(jar.Amount);
			domainEvents.SubscribeToDomainEvents<GotACookieEvent>(ev => Refresh(ev.JarAmount));
			domainEvents.SubscribeToDomainEvents<UnGotACookieEvent>(ev => Refresh(ev.JarAmount));
		}

		void Refresh(int jarAmount)
		{
			FindFirstObjectByType<CookieCounter>().Refresh(jarAmount);
			FindFirstObjectByType<PurchaseAutoclickerButton>().Refresh(jarAmount, jar.AutoclickerPrice);
		}
	}
}

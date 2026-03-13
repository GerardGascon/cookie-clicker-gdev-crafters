using CookieClicker.Runtime.Model;
using UnityEngine;

namespace CookieClicker.Runtime.View
{
	public class GameView : MonoBehaviour
	{
		Jar jar;

		public void Initialize(Jar jar)
		{
			this.jar = jar;
			Refresh(jar.Amount);
			DomainEvents.SubscribeToDomainEvents<GotACookieEvent>(ev => Refresh(ev.JarAmount));
			DomainEvents.SubscribeToDomainEvents<UnGotACookieEvent>(_ => Refresh(jar.Amount));
		}

		void Refresh(int jarAmount)
		{
			FindFirstObjectByType<CookieCounter>().Refresh(jarAmount);
			FindFirstObjectByType<PurchaseAutoclickerButton>().Refresh(jarAmount, jar.AutoclickerPrice);
		}
	}
}

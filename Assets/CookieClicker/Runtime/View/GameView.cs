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
			Refresh();
			DomainEvents.SubscribeToDomainEvents<GotACookieEvent>(_ => Refresh());
			DomainEvents.SubscribeToDomainEvents<UnGotACookieEvent>(_ => Refresh());
		}

		void Refresh()
		{
			FindFirstObjectByType<CookieCounter>().Refresh(jar.Amount);
			FindFirstObjectByType<PurchaseAutoclickerButton>().Refresh(jar.Amount, jar.AutoclickerPrice);
		}
	}
}

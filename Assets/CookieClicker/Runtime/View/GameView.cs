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
			DomainEvents.SubscribeToGotACookie(Refresh);
			DomainEvents.SubscribeToUngotACookie(Refresh);
		}

		void Refresh()
		{
			FindFirstObjectByType<CookieCounter>().Refresh(jar.Amount);
			FindFirstObjectByType<PurchaseAutoclickerButton>().Refresh(jar.Amount, jar.AutoclickerPrice);
		}

		void Refresh(GotACookieEvent obj) {
			Refresh();
		}
	}
}

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
			DomainEvents.SuscribeToGotACookie(Refresh);
			DomainEvents.UngotACookie += Refresh;
		}

		public void Refresh()
		{
			FindFirstObjectByType<CookieCounter>().Refresh(jar.Amount);
			FindFirstObjectByType<PurchaseAutoclickerButton>().Refresh(jar.Amount, jar.AutoclickerPrice);
		}
	}
}

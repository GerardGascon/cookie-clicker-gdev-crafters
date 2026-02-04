using System;

namespace CookieClicker.Runtime.Model
{
	public class Jar
	{
		public int AutoclickerPrice { get; }
		public int Amount
		{
			get => amount;
			private set
			{
				int oldAmount = amount;
				amount = value;
				if (amount > oldAmount) DomainEvents.GotACookie();
			}
		}

		float timePassed;
		public bool isAutoclickerPurchased;

		int amount;

		public Jar()
		{
		}

		public Jar(int autoclickerPrice)
		{
			AutoclickerPrice = autoclickerPrice;
		}

		public bool IsEmpty()
		{
			return Amount == 0;
		}

		public void Add()
		{
			Amount++;
		}

		public void OneSecondHasPassed()
		{
			Amount++;
		}

		public void SecondsHavePassed(float f)
		{
			if (!isAutoclickerPurchased)
				return;

			timePassed += f;
			var cookiesToAdd = (int)timePassed;
			Amount += cookiesToAdd;
			timePassed -= cookiesToAdd;
		}

		public void PurchaseAutoclicker()
		{
			if (Amount < AutoclickerPrice)
			{
				throw new InvalidOperationException();
			}

			Amount -= AutoclickerPrice;
			isAutoclickerPurchased = true;
		}
	}
}

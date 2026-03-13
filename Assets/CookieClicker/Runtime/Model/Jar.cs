using System;

namespace CookieClicker.Runtime.Model
{
	public class Jar
	{
		readonly DomainEvents domainEvents;

		public int AutoclickerPrice { get; }
		public int Amount
		{
			get => amount;
			private set
			{
				int oldAmount = amount;
				amount = value;
				if (amount > oldAmount) domainEvents.RaiseDomainEvent(new GotACookieEvent(amount));
				if (amount < oldAmount) domainEvents.RaiseDomainEvent(new UnGotACookieEvent(amount));
			}
		}

		float timePassed;
		public bool isAutoclickerPurchased;

		int amount;

		public Jar(DomainEvents domainEvents) {
			this.domainEvents = domainEvents;
		}

		public Jar(DomainEvents domainEvents, int autoclickerPrice)
		{
			this.domainEvents = domainEvents;
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

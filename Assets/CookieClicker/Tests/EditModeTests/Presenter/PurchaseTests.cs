using CookieClicker.Runtime.Model;
using CookieClicker.Runtime.Presenter;
using CookieClicker.Tests.EditModeTests.TestDoubles;
using NUnit.Framework;

namespace CookieClicker.Tests.EditModeTests.Presenter
{
	[TestFixture]
	public class PurchaseTests
	{
		[Test]
		public void PurchaseAutoclicker()
		{
			var doc = new Jar();
			var sut = new PurchaseAutoclicker(doc);

			sut.Execute();

			Assert.That(doc.isAutoclickerPurchased);
		}

		[Test]
		public void AutoclickerCantBePurchasedWithoutEnoughCookies()
		{
			var doc = new Jar(3);
			var sut = new PurchaseAutoclicker(doc);

			sut.Execute();

			Assert.That(doc.isAutoclickerPurchased, Is.False);
		}

		[Test]
		public void AutoclickerCanBePurchasedWithEnoughCookies()
		{
			var doc = new Jar(3).WithCookies(3);
			var sut = new PurchaseAutoclicker(doc);

			sut.Execute();

			Assert.That(doc.isAutoclickerPurchased);
		}
	}
}

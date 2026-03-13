using CookieClicker.Runtime.Model;
using NUnit.Framework;

namespace CookieClicker.Tests.EditModeTests.Model
{
	[TestFixture]
	public class PurchaseTests
	{
		[Test]
		public void PurchaseAutoclickerDecreasesCookiesAmountByPrice()
		{
			var doc = new DomainEvents();
			var sut = new Jar(doc, 3).WithCookies(5);

			sut.PurchaseAutoclicker();

			Assert.That(sut.Amount, Is.EqualTo(2));
		}
	}
}

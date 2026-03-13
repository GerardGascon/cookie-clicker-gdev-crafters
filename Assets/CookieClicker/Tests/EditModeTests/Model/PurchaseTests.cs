using CookieClicker.Runtime.Model;
using NUnit.Framework;

namespace CookieClicker.Tests.EditModeTests.Model
{
	[TestFixture]
	public class PurchaseTests
	{
		[SetUp]
		public void SetUp()
		{
			DomainEvents.Reset();
		}

		[Test]
		public void PurchaseAutoclickerDecreasesCookiesAmountByPrice()
		{
			var sut = new Jar(3).WithCookies(5);

			sut.PurchaseAutoclicker();

			Assert.That(sut.Amount, Is.EqualTo(2));
		}
	}
}

using CookieClicker.Runtime.Model;
using CookieClicker.Runtime.Presenter;
using CookieClicker.Tests.EditModeTests.TestDoubles;
using NUnit.Framework;

namespace CookieClicker.Tests.EditModeTests.Presenter
{
	[TestFixture]
	public class EarnCookieTests
	{
		[Test]
		public void EarnCookieAddsOneCookieToJar() {
			var doc1 = new DomainEventBus();
			var doc = new Jar(doc1);
			var sut = new EarnCookie(doc);

			sut.Execute();

			Assert.That(doc.Amount, Is.EqualTo(1));
		}

		[Test]
		public void ViewDisplays1Cookie()
		{
			var doc1 = new DomainEventBus();
			var doc = new Jar(doc1);
			var doc2 = new MockCookieCounterView(doc1);
			var sut = new EarnCookie(doc);

			sut.Execute();

			Assert.That(doc2.Counter, Is.EqualTo(1));
		}

		[Test]
		public void ViewDisplays2Cookies()
		{
			var doc1 = new DomainEventBus();
			var doc = new Jar(doc1);
			var doc2 = new MockCookieCounterView(doc1);
			var sut = new EarnCookie(doc);

			sut.Execute();
			sut.Execute();

			Assert.That(doc2.Counter, Is.EqualTo(2));
		}
	}
}

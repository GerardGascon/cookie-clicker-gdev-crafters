using CookieClicker.Runtime.Model;
using CookieClicker.Runtime.Presenter;
using CookieClicker.Tests.EditModeTests.TestDoubles;
using NUnit.Framework;

namespace CookieClicker.Tests.EditModeTests.Presenter
{
	[TestFixture]
	public class PassTimeTests
	{
		[Test]
		public void PassTime()
		{
			var doc = new Jar().WithAutoclicker();
			var sut = new PassTime(doc);

			sut.Execute(1.2f);

			Assert.That(doc.Amount, Is.EqualTo(1));
		}

		[Test]
		public void AfterPassingTimeViewDisplays1Cookie()
		{
			var doc = new Jar().WithAutoclicker();
			var doc2 = new MockCookieCounterView(doc);
			var sut = new PassTime(doc);

			sut.Execute(1.2f);

			Assert.That(doc2.Counter, Is.EqualTo(1));
		}

		[Test]
		public void AfterPassingTimeMultipleTimesViewDisplaysUpdatedCounter()
		{
			var doc = new Jar().WithAutoclicker();
			var doc2 = new MockCookieCounterView(doc);
			var sut = new PassTime(doc);

			sut.Execute(1.2f);
			sut.Execute(1.2f);
			sut.Execute(1.2f);

			Assert.That(doc2.Counter, Is.EqualTo(3));
		}
	}
}

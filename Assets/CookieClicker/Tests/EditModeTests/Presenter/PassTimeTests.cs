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
			var doc = new Jar(new DomainEvents()).WithAutoclicker();
			var sut = new PassTime(doc);

			sut.Execute(1.2f);

			Assert.That(doc.Amount, Is.EqualTo(1));
		}

		[Test]
		public void AfterPassingTimeViewDisplays1Cookie()
		{
			var doc1 = new DomainEvents();
			var doc = new Jar(doc1).WithAutoclicker();
			var doc2 = new MockCookieCounterView(doc1);
			var sut = new PassTime(doc);

			sut.Execute(1.2f);

			Assert.That(doc2.Counter, Is.EqualTo(1));
		}

		[Test]
		public void AfterPassingTimeMultipleTimesViewDisplaysUpdatedCounter()
		{
			var doc1 = new DomainEvents();
			var doc = new Jar(doc1).WithAutoclicker();
			var doc2 = new MockCookieCounterView(doc1);
			var sut = new PassTime(doc);

			sut.Execute(1.2f);
			sut.Execute(1.2f);
			sut.Execute(1.2f);

			Assert.That(doc2.Counter, Is.EqualTo(3));
		}
	}
}

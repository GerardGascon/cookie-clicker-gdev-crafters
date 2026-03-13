using CookieClicker.Runtime.Model;
using NUnit.Framework;

namespace CookieClicker.Tests.EditModeTests.Model
{
	[TestFixture]
	public class JarTests
	{
		[SetUp]
		public void SetUp()
		{
			DomainEvents.Reset();
		}

		[Test]
		public void JarIsEmptyByDefault()
		{
			var jar = new Jar();

			Assert.That(jar.IsEmpty(), Is.True);
		}

		[Test]
		public void EarnOneCookieJarIsNotEmpty()
		{
			var jar = new Jar();

			jar.Add();

			Assert.That(jar.IsEmpty(), Is.False);
		}

		[Test]
		public void EarnOneCookie()
		{
			var jar = new Jar();

			jar.Add();

			Assert.That(jar.Amount, Is.EqualTo(1));
		}

		[Test]
		public void EarnTwoCookies()
		{
			var jar = new Jar();

			jar.Add();
			jar.Add();

			Assert.That(jar.Amount, Is.EqualTo(2));
		}

		[Test]
		public void CookieIsAddedWhenOneSecondHasPassed()
		{
			var jar = new Jar();

			jar.OneSecondHasPassed();

			Assert.That(jar.Amount, Is.EqualTo(1));
		}

		[TestCase(3f, 3)]
		[TestCase(3.9f, 3)]
		[TestCase(3.2f, 3)]
		public void ThreeCookiesAreAddedWhenThreeSecondsHavePassed(float timePassed, int amountOfCookies)
		{
			var jar = new Jar().WithAutoclicker();

			jar.SecondsHavePassed(timePassed);

			Assert.That(jar.Amount, Is.EqualTo(amountOfCookies));
		}

		[TestCase(0.6f, 1)]
		[TestCase(1.6f, 3)]
		public void CookiesAreAddedWhenTimePassesIn2Increments(float timeIncrement, int amountOfCookies)
		{
			var jar = new Jar().WithAutoclicker();

			jar.SecondsHavePassed(timeIncrement);
			jar.SecondsHavePassed(timeIncrement);

			Assert.That(jar.Amount, Is.EqualTo(amountOfCookies));
		}

		[Test]
		public void GivenJarWithCookies_WhenTimePasses_CookiesAreAdded()
		{
			var jar = new Jar().WithCookies(5).WithAutoclicker();

			jar.SecondsHavePassed(1.2f);
			jar.SecondsHavePassed(1.2f);
			jar.SecondsHavePassed(1.2f);

			Assert.That(jar.Amount, Is.EqualTo(8));
		}
	}
}

using CookieClicker.Runtime.Model;

namespace CookieClicker.Runtime.Presenter
{
	public class PassTime
	{
		readonly Jar jar;

		public PassTime(Jar jar)
		{
			this.jar = jar;
		}

		public void Execute(float time)
		{
			jar.SecondsHavePassed(time);
		}
	}
}

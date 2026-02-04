using CookieClicker.Runtime.Model;

namespace CookieClicker.Runtime.Presenter
{
	public class EarnCookie
	{
		readonly Jar jar;

		public EarnCookie(Jar jar)
		{
			this.jar = jar;
		}

		public void Execute()
		{
			jar.Add();
		}
	}
}

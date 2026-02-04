using CookieClicker.Runtime.Model;

namespace CookieClicker.Runtime.Presenter
{
	public class PassTime
	{
		readonly Jar jar;
		readonly IGameView view;

		public PassTime(Jar jar, IGameView view)
		{
			this.jar = jar;
			this.view = view;
		}

		public void Execute(float time)
		{
			jar.SecondsHavePassed(time);
		}
	}
}

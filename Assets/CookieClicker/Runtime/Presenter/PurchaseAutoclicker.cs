using CookieClicker.Runtime.Model;

namespace CookieClicker.Runtime.Presenter
{
	public class PurchaseAutoclicker
	{
		readonly Jar jar;
		readonly IGameView view;

		public PurchaseAutoclicker(Jar jar, IGameView view)
		{
			this.jar = jar;
			this.view = view;
		}

		public void Execute()
		{
			if (jar.Amount >= jar.AutoclickerPrice)
			{
				jar.PurchaseAutoclicker();
			}
		}
	}
}

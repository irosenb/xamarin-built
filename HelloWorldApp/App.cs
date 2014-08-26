using System;
using Xamarin.Forms;

namespace HelloWorldApp
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage (new LoginView ());	
		}
	}
}


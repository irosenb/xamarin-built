using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace HelloWorldApp
{
	public class LoginView : ContentPage
	{
		public LoginView ()
		{
			BindingContext = new LoginViewModel ();
			Build ();

			Title = "Login";
			Padding = new Thickness (20);

			MessagingCenter.Subscribe<LoginViewModel> (this, "HelloWorldApp.ApartmentPage", (sender) => {
				ApartmentPage ();
			});
		}

		void Build ()
		{
			var username = new Entry {
				Placeholder = "username"
			};

			username.SetBinding (Entry.TextProperty, new Binding ("Username"));

			var password = new Entry {
				Placeholder = "password",
				IsPassword = true
			};

			password.SetBinding (Entry.TextProperty, "Password");

			var submit = new Button { 
				Text = "Submit",
				};
	
			submit.SetBinding (Button.CommandProperty, "LoginCommand");

			var stacklayout = new StackLayout ();

			stacklayout.Children.Add (username);
			stacklayout.Children.Add (password);
			stacklayout.Children.Add (submit);

			Content = stacklayout;
		}
			
		public void ApartmentPage ()
		{
			var page = new ApartmentView ();
			Navigation.PushAsync (page);
		}
	}
}


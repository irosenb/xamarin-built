using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HelloWorldApp
{
	public class LoginViewModel : INotifyPropertyChanged
	{
		public LoginViewModel ()
		{
			loginCommand = new Command (
				() => {
					MessagingCenter.Send<LoginViewModel> (this, "HelloWorldApp.ApartmentPage");
				},
				() => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) 
			);
		}

		Command loginCommand;
		public ICommand LoginCommand { get { return loginCommand; }}

		string username;
		public string Username {
			get {
				return username;
			}
			set {
				if (username == value) {
					return;
				}
				username = value;
				OnPropertyChanged ();
				loginCommand.ChangeCanExecute ();
			}
		}

		string password;
		public string Password {
			get {
				return password;
			}
			set {
				if (password == value) {
					return;
				}
				password = value;
				OnPropertyChanged ();
				loginCommand.ChangeCanExecute ();
			}
		}
			

		public event PropertyChangedEventHandler PropertyChanged;

		void OnPropertyChanged ([CallerMemberName] string propertyName=null)
		{
			var handler = PropertyChanged;
			if (handler != null) {
				handler (this, new PropertyChangedEventArgs (propertyName));
			}
		}
	}
}


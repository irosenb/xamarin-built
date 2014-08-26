using System;
using Xamarin.Forms.Maps;
using Xamarin.Forms;

namespace HelloWorldApp
{
	public class ApartmentView : ContentPage
	{
		class DateTimeConverter : IValueConverter
		{
			#region IValueConverter implementation
			public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				var datetime = (DateTime)value;
				return datetime.ToString();
			}
			public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				throw new NotImplementedException ();
			}
			#endregion
			
		}

		public ApartmentView ()
		{
			Build ();
		}

		void Build() 
		{
			var apartments = new [] {
				new Apartment { Name = "Castro", Location = new Position (37.800937, -122.418369), Time = DateTime.Today },
				new Apartment { Name = "Haight", Location = new Position (37.800937, -122.418369), Time = DateTime.Today },
				new Apartment { Name = "FiDi", Location = new Position (37.800937, -122.418369), Time = DateTime.Today },
				new Apartment { Name = "Russian Hill", Location = new Position (37.800937, -122.418369), Time = DateTime.Today },
				new Apartment { Name = "Castro", Location = new Position (37.800937, -122.418369), Time = DateTime.Today },
				new Apartment { Name = "Castro", Location = new Position (37.800937, -122.418369), Time = DateTime.Today },
			};

			Title = "Apartments";

			var apartmentList = new ListView {
				ItemsSource = apartments
			};

			var dataTemplate = new DataTemplate (typeof(TextCell));

			dataTemplate.SetBinding (TextCell.TextProperty, "Name");

			dataTemplate.SetBinding (TextCell.DetailProperty, new Binding (
				path: "Time",
				converter: new DateTimeConverter())
			);

			apartmentList.ItemTemplate = dataTemplate;

			apartmentList.ItemSelected += (sender, e) => {
				if (e.SelectedItem == null) {
					return;
				}

				Apartment details = (Apartment) e.SelectedItem;
				var page = new ApartmentDetailView (details);
				Navigation.PushAsync (page);
				apartmentList.SelectedItem = null;
			};

			var add = new ToolbarItem {
				Name = "Add",
			};

			ToolbarItems.Add (add);
//			NavigationPage.SetBackButtonTitle (new LoginView (), "Back");
		
			add.Activated += (object sender, EventArgs e) => {
				var page = new ApartmentAddView ();
				Navigation.PushModalAsync (page);
			};

			Content = new StackLayout {
				Children = { apartmentList }
			};

		}
	}
}


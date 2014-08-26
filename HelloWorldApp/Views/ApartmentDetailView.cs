using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;

namespace HelloWorldApp
{
	public class ApartmentDetailView : ContentPage
	{

		public ApartmentDetailView (Apartment apartment)
		{
			Build (apartment);
		}

		async void Build (Apartment apartment)
		{
			var geocode = new Geocoder ();

			var image = new Image {
				Source = "http://www.califliving.com/title24-energy/images/sanfrancisco.jpg",
				Aspect = Aspect.AspectFill,
				Opacity = 0.5,
			};

			var name = new Label {
				Text = apartment.Name,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				Font = Font.SystemFontOfSize(30, FontAttributes.Bold),
				TextColor = Color.White,
			};

			var nameView = new AbsoluteLayout {
				HeightRequest = 170,
				BackgroundColor = Color.Black,
				Children = { 
					{image, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All},  
					{name, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All} 
				},
			};
				
			var addressLabel = new Label {
				Text = "Loading address…",
				XAlign = TextAlignment.Center,
				HeightRequest = 100,
				YAlign = TextAlignment.Center,
			};

			var pin = new Pin {
				Position = apartment.Location,
				Label = apartment.Name
			};
										
			var map = new Map(MapSpan.FromCenterAndRadius (apartment.Location, Distance.FromMiles (0.2))) {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Pins = { pin }
			};

			Content = new StackLayout {
				Children = { nameView, addressLabel, map },
			};

			var address = await geocode.GetAddressesForPositionAsync (apartment.Location);
			addressLabel.Text = address.FirstOrDefault ();
			
		}
	}
}


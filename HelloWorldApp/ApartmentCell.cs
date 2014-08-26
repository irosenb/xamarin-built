using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HelloWorldApp
{
	public class ApartmentCell : ViewCell
	{
		public string Name { get; set; }
		public string Time { get; set; }
		public Position Location { get; set; } 

		public ApartmentCell ()
		{
		}

		static StackLayout CreateApartmentLayout ()
		{
			var nameLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			nameLabel.SetBinding (Label.TextProperty, "Name");

			var timeLabel = new Label { 
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			timeLabel.SetBinding (Label.TextProperty, new Binding (path: "Time", stringFormat: "{}{0:dd/MM/yyyy}"));

			return new StackLayout {
				Children = { nameLabel, timeLabel }
			};

		}
	}
}


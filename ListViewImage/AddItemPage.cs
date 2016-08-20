using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ListViewImage
{

	public class AddItemPage : ContentPage
	{
		public View MakePriceLayout(string name, Color textColor, Color color)
		{
			var layout = new AbsoluteLayout { Padding = new Thickness(5), BackgroundColor = color };
			layout.Children.Add(new Label { Text = name, TextColor = textColor, VerticalTextAlignment = TextAlignment.Center }, new Rectangle(0, 0, .5, .5), AbsoluteLayoutFlags.All);
			layout.Children.Add(new Label { Text = "Waitrose", TextColor = textColor, VerticalTextAlignment = TextAlignment.Center }, new Rectangle(0, 1, .5, .5), AbsoluteLayoutFlags.All);
			layout.Children.Add(new Label { Text = "$10.00", TextColor = textColor, HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center }, new Rectangle(1, .5, .5, .5), AbsoluteLayoutFlags.All);
			return layout;
		}

		public AddItemPage()
		{
			this.Title = "Add item page";

			var layout = new Grid ();
			layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
			layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

			var name = new Entry { Placeholder = "Name" };
			var price = new Entry { Placeholder = "Price", Keyboard = Keyboard.Numeric };
			var low = MakePriceLayout("Low", Color.White, Color.FromHex("#BA68C8"));
			var avg = MakePriceLayout("Average", Color.White, Color.FromHex("#9C27B0"));
			var high = MakePriceLayout("High", Color.White, Color.FromHex("#7B1FA2"));

			var sideLayout = new StackLayout { Margin = new Thickness(5) };
			sideLayout.Children.Add(name);
			sideLayout.Children.Add(price);
			sideLayout.Children.Add(low);
			sideLayout.Children.Add(avg);
			sideLayout.Children.Add(high);
			layout.Children.Add(sideLayout, 1, 0);

			var list = new ListView
			{
				ItemsSource = new List<String> {
					"Baking powder",
					"Budweiser",
					"Colgate",
					"Tissue",
					"Double cream",
					"Beef",
					"Chicken breast"
				},
				ItemTemplate =
						new DataTemplate(() =>
						{
							var template = new TextCell();
							template.TextColor = Color.Gray;
							template.SetBinding(TextCell.TextProperty, ".");
							return template;
						}),
				BackgroundColor = Color.White
			};
			layout.Children.Add(list, 0, 0);

			this.Content = layout;
		}
	}
}


using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ListViewImage
{
	public class Item
	{ 
		public string Name { get; set; }
		public decimal Price { get; set; }
	}

	public class BasketPage : ContentPage
	{
		public BasketPage()
		{
			this.Title = "Basket";


			var layout = new AbsoluteLayout { Margin = new Thickness(0) };
			var currentTotal = new StackLayout
			{
				Padding = new Thickness (20),
				BackgroundColor = Color.FromHex("#42A5F5")
			};

			var label = new Label { Text = "Current total", TextColor = Color.White, HorizontalTextAlignment = TextAlignment.Center, Style = Device.Styles.TitleStyle };
			var total = new Label { Text = "$35.10", TextColor = Color.White, HorizontalTextAlignment = TextAlignment.Center, Style = Device.Styles.SubtitleStyle };
			currentTotal.Children.Add(label);
			currentTotal.Children.Add(total);
			layout.Children.Add(currentTotal, new Rectangle(0, 0, 1, .2), AbsoluteLayoutFlags.All);

			var listLayout =
				new ListView
				{
					ItemsSource = new List<Item> {
						new Item { Name = "Baking powder", Price = 1.5m },
						new Item { Name = "Budweiser", Price = 1.5m },
						new Item { Name = "Colgate", Price = 1.5m },
						new Item { Name = "Tissue", Price = 1.5m },
						new Item { Name = "Double cream", Price = 1.5m },
						new Item { Name = "Beef", Price = 1.5m },
						new Item { Name = "Chicken breast", Price = 1.5m },
						new Item { Name = "Baking powder", Price = 1.5m }
					},
					ItemTemplate =
						new DataTemplate(() =>
						{
							var template = new AbsoluteLayout { Padding = new Thickness { Left = 10, Right = 10 } };
							var name = new Label { HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center };
							var price = new Label { HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center };
							template.Children.Add(name, new Rectangle(0, 0, .5, 1), AbsoluteLayoutFlags.All);
							template.Children.Add(price, new Rectangle(1, 0, .5, 1), AbsoluteLayoutFlags.All);
							name.SetBinding(Label.TextProperty, "Name");
							price.SetBinding(Label.TextProperty, "Price", stringFormat: "{0:C2}");
							return new ViewCell { View = template };
						}),
					SeparatorVisibility = SeparatorVisibility.None,
					BackgroundColor = Color.FromHex("#EEEEEE")
				};

			layout.Children.Add(listLayout, new Rectangle(0, 1, 1, .8), AbsoluteLayoutFlags.All);


			this.ToolbarItems.Add(
				new ToolbarItem(
					"Add new item",
					"",
					async () =>
					{
						await this.Navigation.PushAsync(new AddItemPage());
					})
			);

			this.Content = layout;
		}

	}
}


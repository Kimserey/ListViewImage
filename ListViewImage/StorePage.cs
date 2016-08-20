using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
using FFImageLoading.Forms;
using FFImageLoading.Work;
using FFImageLoading.Transformations;

namespace ListViewImage
{

	public class Store
	{
		public string Name { get; set; }
		public string Image { get; set; }
	}

	public class StorePage : ContentPage
	{
		public StorePage(Store store)
		{

			this.Title = store.Name;

			var image = new CachedImage
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 100,
				DownsampleToViewSize = true,
				Aspect = Aspect.AspectFill,
				Source = store.Image
			};

			var layout = new StackLayout
			{
				Spacing = 0
			};

			var name = new Label
			{
				Text = store.Name,
				TextColor = Color.White,
				Style = Device.Styles.TitleStyle,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center
			};

			var ic_baskets = new CachedImage
			{
				Source = "ic_shopping_cart_white_48dp.png"
			};

			var basketCount = new Label
			{
				Text = "23",
				TextColor = Color.White,
				VerticalTextAlignment = TextAlignment.Center
			};

			var ic_total = new CachedImage
			{
				Source = "ic_monetization_on_white_48dp.png"
			};

			var total = new Label
			{
				Text = "$125",
				TextColor = Color.White,
				VerticalTextAlignment = TextAlignment.Center
			};

			var grid = new Grid { 
				Padding = new Thickness(20, 10),
				BackgroundColor = Color.FromHex("#8E24AA")
			};

			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition());
			grid.RowDefinitions.Add(new RowDefinition());
			grid.Children.Add(name, 0, 2, 0, 1);
			grid.Children.Add(new StackLayout { Orientation = StackOrientation.Horizontal, Children = { ic_baskets, basketCount }, HorizontalOptions = LayoutOptions.CenterAndExpand }, 0, 1);
			grid.Children.Add(new StackLayout { Orientation = StackOrientation.Horizontal, Children = { ic_total, total }, HorizontalOptions = LayoutOptions.CenterAndExpand }, 1, 1);


			var basketList = new ListView
			{
				ItemTemplate = new DataTemplate(() =>
				{
					var t = new TextCell();
					t.TextColor = Color.Gray;
					t.SetBinding(TextCell.TextProperty, ".");
					return t;
				}),
				ItemsSource = new List<string> { "Basket", "Basket", "Basket", "Basket", "Basket", "Basket", "Basket", "Basket", "Basket", "Basket" },
				SeparatorVisibility = SeparatorVisibility.None,
				BackgroundColor = Color.FromHex("#EEEEEE")
			};

			layout.Children.Add(image);
			layout.Children.Add(grid);
			layout.Children.Add(basketList);

			basketList.ItemSelected += async (sender, e) => {
				await this.Navigation.PushAsync(new BasketPage());
			};

			this.Content = layout;
		}
	}
}


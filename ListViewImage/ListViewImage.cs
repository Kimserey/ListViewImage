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
	public class Store { 
		public string Name { get; set; }
		public string Image { get; set; }
	}

	public class StorePage: ContentPage {
		public StorePage(Store store) {

			this.Title = store.Name;

			var image = new CachedImage
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 100,
				DownsampleToViewSize = true,
				Aspect = Aspect.AspectFill,
				Source = store.Image
			};

			var layout = new StackLayout { 
				Spacing = 0
			};

			var name = new Label
			{
				Text = store.Name,
				TextColor = Color.White,
				Style = Device.Styles.TitleStyle,
				VerticalTextAlignment= TextAlignment.Center,
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

			var grid = new Grid { Padding = new Thickness(20, 10, 20, 10), BackgroundColor = Color.Purple };
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
				ItemsSource = new List<string> { "Basket", "Basket", "Basket", "Basket", "Basket", "Basket", "Basket", "Basket", "Basket", "Basket" }
			};

			layout.Children.Add(image);
			layout.Children.Add(grid);
			layout.Children.Add(basketList);

			this.Content = layout;
		}
	}

	public class StoreListPage : ContentPage {

		public StoreListPage() {
			this.Title = "All stores";

			var list = new ListView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemsSource = new List<Store> {
					new Store { Image = "aldi.jpg", Name = "ALDI" },
					new Store { Image = "asda.jpg", Name = "ASDA" },
					new Store { Image = "tesco.jpg", Name = "TESCO" },
					new Store { Image = "waitrose.jpg", Name = "WAITROSE" }
				},
				RowHeight = 200,
				ItemTemplate = new DataTemplate(() =>
				{
					var t = new AbsoluteLayout
					{
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand,
					};

					var image = new CachedImage
					{
						HorizontalOptions = LayoutOptions.FillAndExpand,
						HeightRequest = 200,
						DownsampleToViewSize = true,
						TransparencyEnabled = false,
						Aspect = Aspect.AspectFill,
						TransformPlaceholders = false,
						LoadingPlaceholder = "icon.png",
						ErrorPlaceholder = "icon.png"
					};

					var label = new Label
					{
						TextColor = Color.White,
						BackgroundColor = Color.Purple,
						VerticalTextAlignment = TextAlignment.Center,
						HorizontalTextAlignment = TextAlignment.Center
					};

					label.SetBinding(Label.TextProperty, "Name");
					image.SetBinding(CachedImage.SourceProperty, "Image");

					t.Children.Add(image, new Rectangle(.5, .5, .9, .9), AbsoluteLayoutFlags.All);
					t.Children.Add(label, new Rectangle(1, .8, .5, .2), AbsoluteLayoutFlags.All);
					return new ViewCell { View = t };
				}),
				SeparatorVisibility = SeparatorVisibility.None
			};

			list.ItemTapped += async (sender, e) =>
			{
				list.SelectedItem = null;
				await this.Navigation.PushAsync(new StorePage((Store)e.Item));
			};

			this.Content = list;
		}
	}

	public class App : Application
	{
		public App()
		{
			var content = new StoreListPage();
			MainPage = new NavigationPage(content);
		}
	}
}


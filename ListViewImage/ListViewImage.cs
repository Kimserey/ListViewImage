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

	public class App : Application
	{
		public App()
		{
			var list = new ListView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemsSource = new List<Store> {
					new Store { Image = "aldi.jpg", Name = "Aldi" },
					new Store { Image = "asda.jpg", Name = "Asda" },
					new Store { Image = "tesco.jpg", Name = "Tesco" },
					new Store { Image = "waitrose.jpg", Name = "Waitrose" }
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

			if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android) {
				list.ItemTapped += (sender, e) => {
					list.SelectedItem = null;
				};
			}

			var content = new ContentPage
			{
				Title = "ListViewImage",
				Content = list
			};

			MainPage = new NavigationPage(content);
		}
	}
}


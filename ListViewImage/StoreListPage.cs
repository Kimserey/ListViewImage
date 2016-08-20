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
	public class StoreListPage : ContentPage
	{

		public StoreListPage()
		{
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
				SeparatorVisibility = SeparatorVisibility.None,
				BackgroundColor = Color.FromHex("#EEEEEE")
			};

			list.ItemTapped += async (sender, e) =>
			{
				await this.Navigation.PushAsync(new StorePage((Store)e.Item));
			};

			this.Content = list;
		}
	}
}


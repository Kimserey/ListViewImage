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
	public class App : Application
	{
		public App()
		{
			// The root page of your application
			var content = new ContentPage
			{
				Title = "ListViewImage",
				Content = new ListView
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					ItemsSource = Enumerable.Range(0, 100).Select(i => "image.jpg"),
					RowHeight = 300,
					ItemTemplate = new DataTemplate(() => {
						var t = new AbsoluteLayout {
							HorizontalOptions = LayoutOptions.FillAndExpand,
							VerticalOptions = LayoutOptions.FillAndExpand,
							Margin = new Thickness(10)
						};

						var image = new CachedImage {
							HorizontalOptions = LayoutOptions.FillAndExpand,
							HeightRequest = 300,
							DownsampleToViewSize = true,
							TransparencyEnabled = false,
							Aspect = Aspect.AspectFill,
							CacheDuration = TimeSpan.FromDays(30),
							TransformPlaceholders = false,
							LoadingPlaceholder = "icon.png",
							ErrorPlaceholder = "icon.png"
						};

						image.SetBinding(CachedImage.SourceProperty, ".");

						t.Children.Add(image, new Rectangle(.5, .5, 1, 1), AbsoluteLayoutFlags.All);
						return new ViewCell { View = t }; 
					}),
					SeparatorVisibility = SeparatorVisibility.None
				}
			};

			MainPage = new NavigationPage(content);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}


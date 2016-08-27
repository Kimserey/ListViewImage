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
			var content = new StoreListPage();
			MainPage = new NavigationPage(content);
		}
	}
}


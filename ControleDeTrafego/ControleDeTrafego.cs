using System;

using Xamarin.Forms;
using SQLite;

namespace ControleDeTrafego
{
	public class App : Application
	{
		public App ()
		{
			DbHelper.carregaBanco ();

			MainPage = new NavigationPage(new UiLogin());
		}

		protected override void OnStart ()
		{
			
		}

		protected override void OnSleep ()
		{
			
		}

		protected override void OnResume ()
		{
			
		}
	}
}


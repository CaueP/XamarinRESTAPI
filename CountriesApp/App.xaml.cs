using Xamarin.Forms;

namespace CountriesApp
{
	public partial class App : Application
	{
		private CountriesAppPage _mainPage; 
		public App()
		{
			_mainPage = new CountriesAppPage();

			InitializeComponent();

			MainPage = _mainPage;
		}

		protected override void OnStart()
		{
			_mainPage.Load();
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

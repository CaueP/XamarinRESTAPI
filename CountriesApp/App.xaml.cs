using Xamarin.Forms;

namespace CountriesApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new CountriesAppPage();
		}

		protected override async void OnStart()
		{
			// Handle when your app starts
			var client = new RestClient();

			var json = client.Serialize();

			await MainPage.DisplayAlert("Json: ", json, "Cancel");
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

using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CountriesApp
{
	public partial class CountriesAppPage : ContentPage
	{
		public ObservableCollection<Country> Countries { get; set; }
		private RestClient _client;
		public Command RefreshCommand { get; set;}

		public CountriesAppPage()
		{
			RefreshCommand = new Command(() => Load());

			Countries = new ObservableCollection<Country>();
			_client = new RestClient();

			InitializeComponent();
		}

		public async void Load()
		{
			var result = await _client.GetCountries();

			Countries.Clear();

			foreach (var country in result)
			{
				Countries.Add(country);
			}
			IsBusy = false;
		}
	}
}

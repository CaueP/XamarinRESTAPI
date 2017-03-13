using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CountriesApp
{
	public class RestClient
	{
		public string Serialize()
		{
			var countries = new[] {
				new Country { Name = "Brazil" },
				new Country { Name = "United States" }
			};

			string json = JsonConvert.SerializeObject(countries);

			Debug.WriteLine(json);

			return json;
		}
	
		public void Deserialize()
		{
			var json = Serialize();

			var parsedJson = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);

			foreach (Country country in parsedJson)
			{
				Debug.WriteLine(country.Name);
			}
		}

		public async Task<IEnumerable<Country>> GetCountries()
		{

			return await GetAsJson();
		}

		protected string BaseUrl { get; set; } = "http://restcountries.eu/rest/v1";
		protected async Task<IEnumerable<Country>> GetAsJson()
		{
			
			var result = Enumerable.Empty<Country>();

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(
					new MediaTypeWithQualityHeaderValue("application/json")
				);

				var response = await httpClient.GetAsync(BaseUrl).ConfigureAwait(false);

				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

					if (!string.IsNullOrWhiteSpace(json))
					{
						result = await Task.Run(() =>
						{
							return JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
						})
						.ConfigureAwait(false);
					}
				}
			}
			return result;
		}
	}
}

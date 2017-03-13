using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

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
	}
}

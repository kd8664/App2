using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace App2
{
	class RatesRequest
	{
		private const string url = "https://www.cbr-xml-daily.ru/daily_json.js";

		public Root GetExchangeRates()
		{
			HttpClient httpClient = new HttpClient();
			string request = url;
			HttpResponseMessage response = (httpClient.GetAsync(request).Result).EnsureSuccessStatusCode();
			string responseBody = response.Content.ReadAsStringAsync().Result;

			return JsonConvert.DeserializeObject<Root>(responseBody);
		}
	}
}


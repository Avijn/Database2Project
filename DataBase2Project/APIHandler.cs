using Newtonsoft.Json;

namespace DataBase2Project
{
	public class APIHandler
	{
		public async Task<List<BeerModel>> GetBeerDataList(int AmountOfEntries)
		{
			List<BeerModel> beerList = new List<BeerModel>();

			for (var i = 0; i < AmountOfEntries; i = i + 100)
			{
				List<BeerModel> ApiResultList = await GetApiData();
				ApiResultList.ForEach(item => beerList.Add(item));
			}

			Console.WriteLine(beerList.Count());
			return beerList;
		}

		public async Task<List<BeerModel>> GetApiData()
		{
			HttpClient httpClient = new HttpClient();
			var response = await httpClient.GetAsync("https://random-data-api.com/api/v2/beers?size=100");
			var responseString = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<BeerModel>>(responseString);
		}
	}
}

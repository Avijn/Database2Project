using Passport_game.RandomUser.Models;
using System.ComponentModel;
using System.Text.Json;

namespace Passport_game.RandomUser
{
	public class RandomPersonApi
	{
		private readonly HttpClient _httpClient;

		public RandomPersonApi()
		{
			_httpClient = new HttpClient();
		}

		public async Task<PersonCollectionModel> GetRandomPerson()
		{
			var responseitem = await _httpClient.GetAsync("https://randomuser.me/api/?results=5");
			var responsecontent = await responseitem.Content.ReadAsStringAsync();
			var randomPersonList = JsonSerializer.Deserialize<PersonCollectionModel>(responsecontent);
			return randomPersonList;
		}
	}
}

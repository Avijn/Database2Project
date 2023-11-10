using System.Text.Json.Serialization;

namespace Passport_game.RandomUser.Models
{
	public class PersonCollectionModel
	{
		[JsonPropertyName("results")]
		public List<PersonModel> Results { get; set; }
	}
}

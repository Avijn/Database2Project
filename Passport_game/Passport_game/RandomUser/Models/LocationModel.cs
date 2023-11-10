using System.Text.Json.Serialization;

namespace Passport_game.RandomUser.Models
{
	public class LocationModel
	{
		[JsonPropertyName("state")]
		public string State { get; set; }
		[JsonPropertyName("country")]
		public string Country { get; set; }
	}
}

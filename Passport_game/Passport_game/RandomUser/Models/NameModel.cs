using System.Text.Json.Serialization;

namespace Passport_game.RandomUser.Models
{
	public class NameModel
	{
		[JsonPropertyName("title")]
		public string Title { get; set; }
		[JsonPropertyName("first")]
		public string First { get; set; }
		[JsonPropertyName("last")]
		public string Last { get; set; }
	}
}

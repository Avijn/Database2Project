using System.Text.Json.Serialization;

namespace Passport_game.RandomUser.Models
{
	public class PersonModel
	{
		[JsonPropertyName("gender")]
		public string Gender { get; set; }

		[JsonPropertyName("name")]
		public NameModel Name { get; set; }

		[JsonPropertyName("location")]
		public LocationModel Location { get; set; }

		[JsonPropertyName("dob")]
		public DateOfBirthModel Dob { get; set; }

		[JsonPropertyName("nat")]
		public string Nat { get; set; }

	}
}

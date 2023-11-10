using System.Text.Json.Serialization;

namespace Passport_game.RandomUser.Models
{
	public class DateOfBirthModel
	{
		[JsonPropertyName("date")]
		public DateTime Date { get; set; }
	}
}

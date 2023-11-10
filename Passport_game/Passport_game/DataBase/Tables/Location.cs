using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Passport_game.DataBase.Tables
{
	public class Location
	{
		public int Id { get; set; }
		public int PersonId { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
	}
}

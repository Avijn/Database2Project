
using Microsoft.EntityFrameworkCore;

namespace Passport_game.DataBase.Tables
{
	public class Name
	{
		public int Id { get; set; }
		public int PersonId { get; set; }
		public string title { get; set; }
		public string first { get; set; }
		public string last { get; set; }
	}
}

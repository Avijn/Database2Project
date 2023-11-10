using Microsoft.EntityFrameworkCore;

namespace Passport_game.DataBase.Tables
{
	public class DateOfBirth
	{
		public int Id { get; set; }
		public int PersonId { get; set; }
		public DateTime date { get; set; }
	}
}

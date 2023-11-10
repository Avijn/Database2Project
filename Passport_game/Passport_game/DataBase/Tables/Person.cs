using Microsoft.EntityFrameworkCore;
using Passport_game.RandomUser.Models;

namespace Passport_game.DataBase.Tables
{
	public class Person
	{
		public int Id { get; set; }
		public string Gender { get; set; }
		public string Nat { get; set; }
	}
}

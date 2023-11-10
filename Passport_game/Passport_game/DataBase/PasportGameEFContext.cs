using Microsoft.EntityFrameworkCore;
using Passport_game.DataBase.Tables;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Cryptography.Xml;

namespace Passport_game.DataBase
{
	public class PasportGameEFContext : DbContext
	{
		private readonly string _connectionString;

		public DbSet<Location> Locations { get; set; }
		public DbSet<DateOfBirth> DateOfBirths { get; set; }
		public DbSet<Name> Names { get; set; }
		public DbSet<Person> Persons { get; set; }

		public PasportGameEFContext()
		{
			this._connectionString = @"Server=localhost;Database=PassportGame;User Id=admin;Password=admin;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;";
		}

		public string GetConnectionString()
		{
			return _connectionString;
		}


		protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
		{
			//optionsbuilder.UseSqlServer(_connectionString);
			optionsbuilder.UseSqlServer(GetConnectionString());
			optionsbuilder.EnableSensitiveDataLogging();
		}
	}
}
	
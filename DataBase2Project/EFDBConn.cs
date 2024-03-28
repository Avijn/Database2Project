using Microsoft.EntityFrameworkCore;

namespace DataBase2Project
{
	internal class EFDBConn : DbContext
	{
		private readonly string _connectionString;

		public DbSet<BeerDbModel> Beers { get; set; }

        public EFDBConn()
        {
            _connectionString = @"Server=localhost;Database=BeerCollection;User Id=admin;Password=admin;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;";
        }

        public string GetConnectionString()
		{
			return _connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
		{
			optionsbuilder.UseSqlServer(GetConnectionString());
			optionsbuilder.EnableSensitiveDataLogging();
		}
	}
	
}

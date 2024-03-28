using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DataBase2Project
{
    public class AdoNet
    {
        //change later
        public string connectionString = @"Server=localhost;Database=BeerCollectionAdo;User Id=admin;Password=admin;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;";

        public long GetBeer(int amount)
        {
            var query = $"SELECT TOP ({amount}) * FROM [BeerCollection].[dbo].[Beers]";
            var stopwatch = Stopwatch.StartNew();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var uid = Guid.Parse(reader["uid"].ToString());
                        var beer = new BeerDbModel(
                            int.Parse(reader["id"].ToString()),
                            Guid.Parse(reader["uid"].ToString()),
                            reader["brand"].ToString(),
                            reader["name"].ToString(),
                            reader["style"].ToString(),
                            reader["hop"].ToString(),
                            reader["yeast"].ToString(),
                            reader["malts"].ToString(),
                            reader["ibu"].ToString(),
                            reader["alcohol"].ToString(),
                            reader["blg"].ToString()
                        );
                    }
                }
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public long InsertBeers(List<BeerModel> beers)
        {
            var query = $"INSERT INTO [dbo].[Beers] ([uid] ,[brand] ,[name] ,[style] ,[hop] ,[yeast] ,[malts] ,[ibu] ,[alcohol] ,[blg]) " +
                "VALUES(@uid, @brand, @name, @style, @hop, @yeasts, @malts, @ibu, @alochol, @blg)";

            var stopwatch = Stopwatch.StartNew();
            using (var connection = new SqlConnection(connectionString))
            {

                foreach (var beer in beers)
                {
                    var cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add("@uid", SqlDbType.UniqueIdentifier).Value = beer.uid;
                    cmd.Parameters.Add("@brand", SqlDbType.NVarChar).Value = beer.brand;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = beer.name;
                    cmd.Parameters.Add("@style", SqlDbType.NVarChar).Value = beer.style;
                    cmd.Parameters.Add("@hop", SqlDbType.NVarChar).Value = beer.hop;
                    cmd.Parameters.Add("@yeasts", SqlDbType.NVarChar).Value = beer.yeast;
                    cmd.Parameters.Add("@malts", SqlDbType.NVarChar).Value = beer.malts;
                    cmd.Parameters.Add("@ibu", SqlDbType.NVarChar).Value = beer.ibu;
                    cmd.Parameters.Add("@alochol", SqlDbType.NVarChar).Value = beer.alcohol;
                    cmd.Parameters.Add("@blg", SqlDbType.NVarChar).Value = beer.blg;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public long DeleteBeers(List<BeerModel> beers)
        {
            var query = $"DELETE FROM [dbo].[Beers] WHERE [uid] = @uid";
            var stopwatch = Stopwatch.StartNew();
            using (var connection = new SqlConnection(connectionString))
            {
                foreach (var beer in beers)
                {
                    var cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add("@uid", SqlDbType.UniqueIdentifier).Value = beer.uid;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long UpdateBeers(List<BeerModel> beers)
        {
            var query = $"UPDATE [dbo].[Beers] SET [alcohol] = 'ITS OVER 9000!!!' WHERE [uid] = @uid";
            var stopwatch = Stopwatch.StartNew();
            using (var connection = new SqlConnection(connectionString))
            {
                foreach (var beer in beers)
                {
                    var cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add("@uid", SqlDbType.UniqueIdentifier).Value = beer.uid;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}

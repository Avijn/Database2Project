using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;

namespace DataBase2Project.MongoDB
{
    public class MongoDbConn
    {
        const string connectionUri = "mongodb+srv://arjanv:Ilx5Kh7MwE5jHhWx@cluster0.iqrceqv.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

        public long InsertIntoMongoDB(List<BeerModel> beers)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            var dbClient = new MongoClient(settings);
            var database = dbClient.GetDatabase("Db2Project");
            var collection = database.GetCollection<BsonDocument>("beer");
            var beerList = new List<BsonDocument>();

            foreach (BeerModel beer in beers)
            {
                var document = new BsonDocument
                {
                    { "uid", beer.uid.ToString() },
                    { "brand", beer.brand},
                    { "name", beer.name },
                    { "style", beer.style },
                    { "hop", beer.hop },
                    { "yeast", beer.yeast },
                    { "malts", beer.malts },
                    { "ibu", beer.ibu},
                    { "alcohol", beer.alcohol },
                    { "blg", beer.blg }
                };
                beerList.Add(document);
            }

            var stopwatch = Stopwatch.StartNew();

            try
            {
                collection.InsertMany(beerList);
            }
            catch (Exception)
            {
                throw;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public long SelectBeersMongoDB(int amount)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            var dbClient = new MongoClient(settings);
            var database = dbClient.GetDatabase("Db2Project");
            var collection = database.GetCollection<BsonDocument>("beer");


            var stopwatch = Stopwatch.StartNew();
            var result = collection.Find(x => true).Limit(amount).ToList();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public long UpdateBeers(List<BeerModel> beers)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            var dbClient = new MongoClient(settings);
            var database = dbClient.GetDatabase("Db2Project");
            var collection = database.GetCollection<BeerDbModel>("beer");

            var stopwatch = Stopwatch.StartNew();
            foreach (var beer in beers)
            {
                var name = beer.name;
                var newValue = "New Name";

                var filter = Builders<BeerDbModel>.Filter.Eq(b => b.name, name);

                var update = Builders<BeerDbModel>.Update.Set(b => b.name, newValue);
                collection.UpdateOne(filter, update);

            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public long DeleteBeers(List<BeerModel> beers)
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            var dbClient = new MongoClient(settings);
            var database = dbClient.GetDatabase("Db2Project");
            var collection = database.GetCollection<BeerDbModel>("beer");

            var stopwatch = Stopwatch.StartNew();
            collection.DeleteMany(x => x.uid == beers
                .Where(beer => beer.uid == x.uid)
                .First<BeerModel>().uid);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

    }
}

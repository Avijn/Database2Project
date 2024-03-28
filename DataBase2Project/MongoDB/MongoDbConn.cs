using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Diagnostics;
using static MongoDB.Driver.WriteConcern;
using System.Xml.Linq;

namespace DataBase2Project.MongoDB
{
    public class MongoDbConn
    {
        const string connectionUri = "mongodb+srv://arjanv:Ilx5Kh7MwE5jHhWx@cluster0.iqrceqv.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
        // Set the ServerApi field of the settings object to set the version of the Stable API on the client

        public void CreateConn()
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            var dbClient = new MongoClient(settings);
            var database = dbClient.GetDatabase("Db2Project");
            var collection = database.GetCollection<BeerDbModel>("beer");

            try
            {
                var result = dbClient.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

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


        /*
         * HIER MEE VERDER
         */
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

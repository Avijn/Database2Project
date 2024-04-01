using DataBase2Project;
using DataBase2Project.MongoDB;

var apiHandler = new APIHandler();
var adoNet = new AdoNet();
var eFService = new EFService();
var mongoDBConn = new MongoDbConn();
var beerlist = eFService.GetBeersWithoutTimer(100000);
run();
void run()
{
    Console.WriteLine("SELECT");
    Console.WriteLine(" Ado.Net :");
    adoNet.GetBeer(1);
    Console.WriteLine("     Miliseconds for 1 row:       " + adoNet.GetBeer(1));
    Console.WriteLine("     Miliseconds for 10 row:      " + adoNet.GetBeer(10));
    Console.WriteLine("     Miliseconds for 100 row:     " + adoNet.GetBeer(100));
    Console.WriteLine("     Miliseconds for 1000 row:    " + adoNet.GetBeer(1000));

    Console.WriteLine("\n Entity framework :");
    eFService.GetBeersWithoutTimer(1);
    Console.WriteLine("     Miliseconds for 1 row:       " + eFService.GetBeers(1));
    Console.WriteLine("     Miliseconds for 10 row:      " + eFService.GetBeers(10));
    Console.WriteLine("     Miliseconds for 100 row:     " + eFService.GetBeers(100));
    Console.WriteLine("     Miliseconds for 1000 row:    " + eFService.GetBeers(1000));

    Console.WriteLine("\n MongoDB :");
    mongoDBConn.SelectBeersMongoDB(1);
    Console.WriteLine("     Miliseconds for 1 row:       " + mongoDBConn.SelectBeersMongoDB(1));
    Console.WriteLine("     Miliseconds for 10 row:      " + mongoDBConn.SelectBeersMongoDB(10));
    Console.WriteLine("     Miliseconds for 100 row:     " + mongoDBConn.SelectBeersMongoDB(100));
    Console.WriteLine("     Miliseconds for 1000 row:    " + mongoDBConn.SelectBeersMongoDB(1000));

    Console.WriteLine("\n\nCREATE :");
    Console.WriteLine("\n Ado.Net :");
    Console.WriteLine("     Miliseconds for 1 row:       " + adoNet.InsertBeers(beerlist.GetRange(0, 1)));
    Console.WriteLine("     Miliseconds for 10 row:      " + adoNet.InsertBeers(beerlist.GetRange(0, 10)));
    Console.WriteLine("     Miliseconds for 100 row:     " + adoNet.InsertBeers(beerlist.GetRange(0, 100)));
    Console.WriteLine("     Miliseconds for 1000 row:    " + adoNet.InsertBeers(beerlist.GetRange(0, 1000)));

    Console.WriteLine("\n Entity framework :");
    Console.WriteLine("     Miliseconds for 1 row:       " + eFService.InsertBeers(beerlist.GetRange(0, 1)));
    Console.WriteLine("     Miliseconds for 10 row:      " + eFService.InsertBeers(beerlist.GetRange(0, 10)));
    Console.WriteLine("     Miliseconds for 100 row:     " + eFService.InsertBeers(beerlist.GetRange(0, 100)));
    Console.WriteLine("     Miliseconds for 1000 row:    " + eFService.InsertBeers(beerlist.GetRange(0, 1000)));

    Console.WriteLine("\n MongoDB :");
    Console.WriteLine("     Miliseconds for 1 row:       " + mongoDBConn.InsertIntoMongoDB(beerlist.GetRange(0, 1)));
    Console.WriteLine("     Miliseconds for 10 row:      " + mongoDBConn.InsertIntoMongoDB(beerlist.GetRange(0, 10)));
    Console.WriteLine("     Miliseconds for 100 row:     " + mongoDBConn.InsertIntoMongoDB(beerlist.GetRange(0, 100)));
    Console.WriteLine("     Miliseconds for 1000 row:    " + mongoDBConn.InsertIntoMongoDB(beerlist.GetRange(0, 1000)));

    Console.WriteLine("\n\nUPDATE :");
    Console.WriteLine("\n Ado.Net :");
    Console.WriteLine("     Miliseconds for 1 row:       " + adoNet.UpdateBeers(beerlist.GetRange(0, 1)));
    Console.WriteLine("     Miliseconds for 10 row:      " + adoNet.UpdateBeers(beerlist.GetRange(0, 10)));
    Console.WriteLine("     Miliseconds for 100 row:     " + adoNet.UpdateBeers(beerlist.GetRange(0, 100)));
    Console.WriteLine("     Miliseconds for 1000 row:    " + adoNet.UpdateBeers(beerlist.GetRange(0, 1000)));

    Console.WriteLine("\n Entity framework :");
    Console.WriteLine("     Miliseconds for 1 row:       " + eFService.UpdateBeers(beerlist.GetRange(0, 1)));
    Console.WriteLine("     Miliseconds for 10 row:      " + eFService.UpdateBeers(beerlist.GetRange(0, 10)));
    Console.WriteLine("     Miliseconds for 100 row:     " + eFService.UpdateBeers(beerlist.GetRange(0, 100)));
    Console.WriteLine("     Miliseconds for 1000 row:    " + eFService.UpdateBeers(beerlist.GetRange(0, 1000)));

    Console.WriteLine("\n MongoDB :");
    Console.WriteLine("     Miliseconds for 1 row:       " + mongoDBConn.UpdateBeers(beerlist.GetRange(0, 1)));
    Console.WriteLine("     Miliseconds for 10 row:      " + mongoDBConn.UpdateBeers(beerlist.GetRange(0, 1)));
    Console.WriteLine("     Miliseconds for 100 row:     " + mongoDBConn.UpdateBeers(beerlist.GetRange(0, 100)));
    Console.WriteLine("     Miliseconds for 1000 row:    " + mongoDBConn.UpdateBeers(beerlist.GetRange(0, 100)));


    Console.WriteLine("\n\nDELETE :");
    Console.WriteLine("\n Ado.Net :");
    Console.WriteLine("     Miliseconds for 1 row:       " + adoNet.DeleteBeers(beerlist.GetRange(0, 1)));
    Console.WriteLine("     Miliseconds for 10 row:      " + adoNet.DeleteBeers(beerlist.GetRange(0, 10)));
    Console.WriteLine("     Miliseconds for 100 row:     " + adoNet.DeleteBeers(beerlist.GetRange(0, 100)));
    Console.WriteLine("     Miliseconds for 1000 row:    " + adoNet.DeleteBeers(beerlist.GetRange(0, 1000)));

    Console.WriteLine("\n Entity framework :");
    Console.WriteLine("     Miliseconds for 1 row:       " + eFService.DeleteBeers(beerlist.GetRange(0, 1)));
    Console.WriteLine("     Miliseconds for 10 row:      " + eFService.DeleteBeers(beerlist.GetRange(0, 10)));
    Console.WriteLine("     Miliseconds for 100 row:     " + eFService.DeleteBeers(beerlist.GetRange(0, 100)));
    Console.WriteLine("     Miliseconds for 1000 row:    " + eFService.DeleteBeers(beerlist.GetRange(0, 1000)));

    Console.WriteLine("\n MongoDB :");
    Console.WriteLine("     Miliseconds for 1 row:       " + mongoDBConn.DeleteBeers(beerlist.GetRange(0, 1)));
    Console.WriteLine("     Miliseconds for 10 row:      " + mongoDBConn.DeleteBeers(beerlist.GetRange(0, 10)));
    Console.WriteLine("     Miliseconds for 100 row:     " + mongoDBConn.DeleteBeers(beerlist.GetRange(0, 100)));
    Console.WriteLine("     Miliseconds for 1000 row:    " + mongoDBConn.DeleteBeers(beerlist.GetRange(0, 1000)));
}

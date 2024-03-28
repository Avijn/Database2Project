using System.Diagnostics;

namespace DataBase2Project
{
    public class EFService
	{
		private readonly EFDBConn _efdbconn;
		public EFService()
		{
			_efdbconn = new EFDBConn();
		}

		public long GetBeers(int amount)
		{
			var stopwatch = Stopwatch.StartNew();
			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}
		
		public List<BeerModel> GetBeersWithoutTimer(int amount)
		{
			var allBeers = _efdbconn.Beers.Take(amount).ToList<BeerDbModel>();
			var beerList = new List<BeerModel>();
			foreach(var beer in allBeers)
			{
				beerList.Add(new BeerModel()
				{
					uid = Guid.NewGuid(),
					brand = beer.brand,
					name = beer.name,
					style = beer.style,
					hop = beer.hop,
					yeast = beer.yeast,
					malts = beer.malts,
					ibu = beer.ibu,
					alcohol = beer.alcohol,
					blg = beer.blg
				});
			}
			return beerList;
		}

		public long InsertBeers(List<BeerModel> beerList)
		{
			var stopwatch = Stopwatch.StartNew();
			
			foreach(var beer in beerList)
			{
				var beerDbModel = new BeerDbModel(beer.uid, beer.brand, beer.name, beer.style, beer.hop, beer.yeast, beer.malts, beer.ibu, beer.alcohol, beer.blg);
				_efdbconn.Beers.Add(beerDbModel);
			}
			_efdbconn.SaveChanges();

			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}

		public long DeleteBeers(List<BeerModel> beerList)
		{
			var stopwatch = Stopwatch.StartNew();
			var allBeersThatNeedToBeDeleted = new List<BeerDbModel>();
			foreach(var beer in beerList)
			{
                allBeersThatNeedToBeDeleted.Add(_efdbconn.Beers.Where(x => x.uid == beer.uid).FirstOrDefault());
            }	
            foreach (var beer in allBeersThatNeedToBeDeleted)
            {
				var beerDbModel = beer;
                _efdbconn.Beers.Remove(beerDbModel);
            }

            _efdbconn.SaveChanges();
            stopwatch.Stop();

			return stopwatch.ElapsedMilliseconds;
		}

        public long UpdateBeers(List<BeerModel> beerList)
        {
            var stopwatch = Stopwatch.StartNew();

            foreach (var beer in beerList)
            {
                var beerDbModel = new BeerDbModel(beer.uid, beer.brand, beer.name, beer.style, beer.hop, beer.yeast, beer.malts, beer.ibu, "ITS OVER 9000!!!", beer.blg);
                _efdbconn.Beers.Update(beerDbModel);
            }
            _efdbconn.SaveChanges();
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}

using Passport_game.DataBase.Tables;
using Passport_game.RandomUser.Models;
using Passport_game.RandomUser;
using Passport_game.DataBase;

namespace Passport_game.Service
{
	public class RandomPersonService
	{
		private RandomPersonApi randomPersonApi;
		private PasportGameEFContext Db;

		public RandomPersonService()
		{
			randomPersonApi = new RandomPersonApi();
			Db = new PasportGameEFContext();
		}
		public async void AddRandomPerson()
		{
			PersonCollectionModel randomPersonList = await randomPersonApi.GetRandomPerson();
			try
			{
				foreach (PersonModel person in randomPersonList.Results)
				{
					Person dbperson = new Person { Gender = person.Gender, Nat = person.Nat };
					Db.Persons.Add(dbperson);
					Db.SaveChanges();
					DateOfBirth dbdob = new DateOfBirth { date = person.Dob.Date, PersonId = dbperson.Id };
					Location dblocation = new Location { State = person.Location.State, Country = person.Location.Country, PersonId = dbperson.Id };
					Name dbname = new Name { title = person.Name.Title, first = person.Name.First, last = person.Name.Last, PersonId = dbperson.Id };

					Db.DateOfBirths.Add(dbdob);
					Db.Locations.Add(dblocation);
					Db.Names.Add(dbname);
					Db.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public PersonModel GetRandomPersonList(int id)
		{
			try
			{
				var person = Db.Persons.Single(item => item.Id == id);
				var name = Db.Names.Single<Name>(item => item.PersonId == id);
				var location = Db.Locations.Single<Location>(item => item.PersonId == id);
				var dob = Db.DateOfBirths.Single<DateOfBirth>(item => item.PersonId == id);

				var Jasonpearson = new PersonModel
				{
					Gender = person.Gender,
					Name = new NameModel()
					{
						Title = name.title,
						First = name.first,
						Last = name.last
					},
					Location = new LocationModel()
					{
						State = location.State,
						Country = location.Country,
					},
					Dob = new DateOfBirthModel()
					{
						Date = dob.date
					},
					Nat = person.Nat
				};
				return Jasonpearson;
			}
			catch(Exception) 
			{
				throw;
			}
		}
	}
}

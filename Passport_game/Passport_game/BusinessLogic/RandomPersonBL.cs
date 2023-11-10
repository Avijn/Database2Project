using Passport_game.DataBase;
using Passport_game.DataBase.Tables;
using Passport_game.RandomUser;
using Passport_game.RandomUser.Models;
using Passport_game.Service;

namespace Passport_game.BusinessLogic
{
	public class RandomPersonBL
	{
		private RandomPersonService randomPersonService;

		public RandomPersonBL()
		{
			randomPersonService = new RandomPersonService();
		}

		public void AddRandomPerson()
		{
			try
			{
				randomPersonService.AddRandomPerson();
			}
			catch(Exception)
			{
				throw;
			}
		}

		public PersonModel GetRandomPerson(int id)
		{
			try
			{
				return randomPersonService.GetRandomPersonList(id);
			}
			catch(Exception)
			{
				throw;
			}
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Passport_game.BusinessLogic;
using Passport_game.RandomUser;
using Passport_game.RandomUser.Models;

namespace Passport_game.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class Controller : ControllerBase
    {
        [HttpGet("AddRandomPerson")]
        public async Task<IActionResult> AddRandomPerson()
        {
            RandomPersonBL randomUserBL = new RandomPersonBL();
            randomUserBL.AddRandomPerson();

			return Ok();
        }

        [HttpGet("GetRandomPerson")]
        public async Task<IActionResult> GetRandomPerson(int id)
        {
            RandomPersonBL randomUserBL = new RandomPersonBL();
            PersonModel randomUser = randomUserBL.GetRandomPerson(id);

            return Ok(randomUser);

		}
    }
}

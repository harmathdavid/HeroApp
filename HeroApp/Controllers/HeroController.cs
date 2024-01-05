using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace HeroApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HeroController : ControllerBase
    {
        private readonly ITournament _tournament;

        public HeroController(ITournament tournament)
        {
            _tournament = tournament;
        }

        [HttpGet]
        public IActionResult RandomHeroGenerator(int numberOfHeroes)
        {
            IArena arena = new Arena();
            arena.GenerateHeroes(numberOfHeroes);

            _tournament.Arenas.Add(arena);

            return Ok(arena.ID);
        }

        [HttpGet]
        public IActionResult Battle(int arenaID)
        {
            return Ok(_tournament.StartFight(arenaID));
        }
    }
}
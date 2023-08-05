using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero { id = 1,
                                name =  "Spiderman",
                                FirstName = "Peter",
                                LastName = "Parker",
                                Place = "New York City"
                },
                new SuperHero { id = 2,
                                name =  "Hulk",
                                FirstName = "Bruce",
                                LastName = "Banner",
                                Place = "Unknown"
                }
            };

        [HttpGet]   
        public async Task<ActionResult<List<SuperHero>>> Get()
        { 
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(h => h.id == id);
            if (hero == null)
                return BadRequest("Hero Not Found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

    }
}

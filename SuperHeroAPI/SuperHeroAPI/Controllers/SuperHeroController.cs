using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //private static List<SuperHero> heroes = new List<SuperHero>
        //    {
        //        new SuperHero { id = 2,
        //                        name =  "Hulk",
        //                        FirstName = "Bruce",
        //                        LastName = "Banner",
        //                        Place = "Unknown"
        //        }
        //    };
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]   
        public async Task<ActionResult<List<SuperHero>>> Get()
        { 
            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _context.superHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero Not Found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.superHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var dbHero = await _context.superHeroes.FindAsync(request.id);
            if (dbHero == null)
                return BadRequest("Hero Not Found");

            dbHero.name = request.name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var dbhero = await _context.superHeroes.FindAsync(id);
            if (dbhero == null)
                return BadRequest("Hero Not Found");
            _context.superHeroes.Remove(dbhero);
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }

    }
}

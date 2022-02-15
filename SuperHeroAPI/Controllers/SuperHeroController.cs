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
             new SuperHero { Id = 1,
                    Name ="Spider Man",
                    FirstName ="peter",
                    LastName ="parker",
                    Place="New York City"
                },
                new SuperHero {
                    Id = 2,
                    Name ="Iron Man",
                    FirstName ="Tony",
                    LastName ="Stark",
                    Place="New York City"
                }
        };

        private readonly DataContexthero _Context;

        public SuperHeroController(DataContexthero Context)
        {
            _Context = Context;
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero(SuperHero hero)
        {
            _Context.SuperHeroes.Add(hero);
            await _Context.SaveChangesAsync();
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<SuperHero>>> GetbyId(int Id)
        {
            var hero = await _Context.SuperHeroes.FindAsync(Id);
            if (hero == null)
                return BadRequest();
            return Ok(hero);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<SuperHero>> Remove(int Id)
        {
            var hero = _Context.SuperHeroes.Find(Id);
            if (hero == null)
                return BadRequest();
            _Context.SuperHeroes.Remove(hero);
            _Context.SaveChanges();
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateById(SuperHero hero)
        {
            var hero1 = _Context.SuperHeroes.Find(hero.Id);
            if (hero1 == null)
                return BadRequest();
            hero1.Name = hero.Name;
            hero1.FirstName = hero.FirstName;
            hero1.LastName = hero.LastName;
            hero1.Place = hero.Place;
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }
    }
}
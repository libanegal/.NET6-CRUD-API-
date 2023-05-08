using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private static List<Superhero> heroes = new List<Superhero>
            {
                new Superhero
                {
                    Id = 1,
                    Name = "SPider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },
                 new Superhero
                {
                    Id = 2,
                    Name = "Ironman",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Long Island"
                }

            };
        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> Get()
        {
            
            return Ok(heroes);
 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Superhero>>> Get(int id)
        {

            var hero = heroes.Find(h => h.Id == id);
            if (hero == null) 
            {
                return BadRequest("Request not found");
            }
            return Ok(hero);

        }
        [HttpPost]
        public async Task<ActionResult<List<Superhero>>> AddHero(Superhero hero)
        {
            var hero1 = heroes.Find(h => h.Id == hero.Id);

            if (hero1 != null)
            {
                return BadRequest("Record with the same Id Already Exists");
                    
            }


            heroes.Add(hero);
            return Ok(heroes);



        }

        [HttpPut]
        public async Task<ActionResult<List<Superhero>>> UpdateHero(Superhero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
            {
                return BadRequest("Request not found");
            }
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            
            return Ok(heroes);

           

        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Superhero>>> Delete(int id)
        {

            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Request not found");

            }
            heroes.Remove(hero);
            return Ok(heroes);

        }
    }
}

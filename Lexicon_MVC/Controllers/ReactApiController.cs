using Lexicon_MVC.Data;
using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_MVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReactApiController : ControllerBase
    {
        readonly ApplicationDbContext? _dbContext; // creates a readonly of DbContext

        public ReactApiController(ApplicationDbContext? dbContext) // Adds a context to a constructor
        {
            _dbContext = dbContext; // Initiates the value
        }

   
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var people = await _dbContext.People.Include(p => p.Languages).ToListAsync();
            return Ok(people);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePersonViewModel p)
        {
            var newPerson = new Person()
            {
                Name = p.Name,
                CityId = p.CityId,
                PhoneNumber = p.PhoneNumber,
            };


            _dbContext.People.Add(newPerson);
            await _dbContext.SaveChangesAsync();

            return Ok(newPerson);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userToDelete = new Person() { PersonId = id };
            //var userToDelete = await _dbContext.People.FindAsync(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            _dbContext.People.Remove(userToDelete);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("getcountries")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _dbContext.Countries.Include(c => c.Cities).ToListAsync();
            return Ok(countries);
        }


        [HttpGet("getcities")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _dbContext.People.Include(p => p.City).ToListAsync();
            return Ok(cities);
        }

    }
}

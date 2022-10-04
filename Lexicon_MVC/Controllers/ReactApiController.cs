using Lexicon_MVC.Data;
using Lexicon_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lexicon_MVC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReactApiController : ControllerBase
    {
        readonly ApplicationDbContext? _dbContext; // creates a readonly of DbContext

        public ReactApiController(ApplicationDbContext? dbContext) // Adds a context to a constructor
        {
            _dbContext = dbContext; // Initiates the value
        }

   
        [HttpGet("people/{id}")]
        [ProducesResponseType(200)]
        public ActionResult<Person> Get(int id)
        {
            Console.WriteLine("HHIIITTTTT"); Person myPerson = new Person() { Name = "Jörgen Jönsson", PhoneNumber = "031-330330", PersonId = id };

            return myPerson;
        }


    }
}

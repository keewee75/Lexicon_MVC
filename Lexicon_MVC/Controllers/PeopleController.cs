using Lexicon_MVC.Data;
using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lexicon_MVC.Controllers
{
    public class PeopleController : Controller
    {

        public static PeopleViewModel peopleViewModel = new PeopleViewModel();
        private static int idCounter = peopleViewModel.People.Count;
        readonly ApplicationDbContext? _dbContext; // creates a readonly of DbContext

        public PeopleController(ApplicationDbContext? dbContext) // Adds a context to a constructor
        {
            _dbContext = dbContext; // Initiates the value
        }

        public IActionResult Index()
        {
            peopleViewModel.People = _dbContext.People.ToList();
            
            return View(peopleViewModel);
        }

        public IActionResult Search(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                ViewBag.Message = "";
                return View("Index", peopleViewModel);
            }

            StringComparison comp = StringComparison.OrdinalIgnoreCase;
            var filteredPeople = peopleViewModel.People
                .Where(x => x.Name.Contains(searchString, comp) || x.City.Contains(searchString, comp)).ToList();
            var m = new PeopleViewModel();
            m.People = filteredPeople;
            if (filteredPeople.Count == 0)
            {
                ViewBag.Message = "No data was found for your search criteria";
            }
            return View("Index", m);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            //ta bort personen med rätt id
            //peopleViewModel.People.RemoveAll(x => x.PersonId == id);
            using (_dbContext)
            {
               var removePerson = new Person() { PersonId = id };
                _dbContext.People.Remove(removePerson);
                _dbContext.SaveChanges();
                peopleViewModel.People = _dbContext.People.ToList();
            }
            

            return View("Index", peopleViewModel);

        }

        [HttpPost]
        public IActionResult AddPerson(PeopleViewModel p)
        {

            if (ModelState.IsValid)
            {
                using (_dbContext)
                {
                    var newPerson = new Person()
                    {
                        Name = p.cpvm.Name,
                        City = p.cpvm.City,
                        PhoneNumber = p.cpvm.PhoneNumber,
                    };
                    _dbContext.People.Add(newPerson);
                    _dbContext.SaveChanges();
                    peopleViewModel.People = _dbContext.People.ToList();
                }
            }
            else
            {
                var i = ModelState.ErrorCount;
            }
            
            return View("Index", peopleViewModel);
        }

    }
}

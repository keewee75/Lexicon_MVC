using Lexicon_MVC.Data;
using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lexicon_MVC.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {

        public static PeopleViewModel peopleViewModel = new PeopleViewModel();
        readonly ApplicationDbContext? _dbContext; // creates a readonly of DbContext

        public PeopleController(ApplicationDbContext? dbContext) // Adds a context to a constructor
        {
            _dbContext = dbContext; // Initiates the value
        }

        public IActionResult Index()
        {
            ViewBag.CityNames = new SelectList(_dbContext.Cities, "CityId", "CityName");
            peopleViewModel.People = _dbContext.People.Include(c => c.City).ToList();

            return View(peopleViewModel);
        }

        public IActionResult Search(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                ViewBag.CityNames = new SelectList(_dbContext.Cities, "CityId", "CityName");
                ViewBag.Message = "";
                return View("Index", peopleViewModel);
            }

            StringComparison comp = StringComparison.OrdinalIgnoreCase;
            var filteredPeople = peopleViewModel.People
                .Where(x => x.Name.Contains(searchString, comp) || x.City.CityName.Contains(searchString, comp)).ToList();
            var m = new PeopleViewModel();
            m.People = filteredPeople;
            if (filteredPeople.Count == 0)
            {
                ViewBag.Message = "No data was found for your search criteria";
            }

            return View("Index", m);
        }

        public IActionResult Edit(int id)
        {
           // ViewBag.CityNames = new SelectList(_dbContext.Cities, "CityId", "CityName");
            //ViewBag.CityNames = _dbContext.Cities.ToList();
            var person = _dbContext.People.FirstOrDefault(x=> x.PersonId == id);
            EditPersonViewModel m = new EditPersonViewModel();
            m.Name = person.Name;
            m.PersonId = person.PersonId;
            m.CityId = person.CityId;
            m.PhoneNumber = person.PhoneNumber;
            m.Cities = _dbContext.Cities.ToList();
            return View(m);
        }

        [HttpPost]
        public IActionResult Edit(EditPersonViewModel m, int cityId)
        {
            Person p = new Person();
            p.Name = m.Name;
            p.PersonId = m.PersonId;
            p.CityId = cityId;
            p.PhoneNumber = m.PhoneNumber;
            _dbContext.Update(p);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
     
        public IActionResult Delete(int id)
        {

            //ta bort personen med rätt id

            var removePerson = new Person() { PersonId = id };
            _dbContext.People.Remove(removePerson);
            _dbContext.SaveChanges();
            peopleViewModel.People = _dbContext.People.ToList();

            ViewBag.CityNames = new SelectList(_dbContext.Cities, "CityId", "CityName");
            return View("Index", peopleViewModel);
        }

        [HttpPost]
        public IActionResult AddPerson(PeopleViewModel p, int cityId)
        {

            if (ModelState.IsValid && cityId > 0)
            {

                var newPerson = new Person()
                {
                    Name = p.cpvm.Name,
                    CityId = cityId,
                    PhoneNumber = p.cpvm.PhoneNumber,
                };
                _dbContext.People.Add(newPerson);
                _dbContext.SaveChanges();
                peopleViewModel.People = _dbContext.People.ToList();

            }
            else
            {
                var i = ModelState.ErrorCount;
            }
            ViewBag.CityNames = new SelectList(_dbContext.Cities, "CityId", "CityName");
            return View("Index", peopleViewModel);
        }
    }
}

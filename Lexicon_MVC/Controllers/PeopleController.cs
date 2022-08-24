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
        public IActionResult Index()
        {

            return View(peopleViewModel);

        }

        public IActionResult Search(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                ViewBag.Message = "";
                return View("Index", peopleViewModel);
            }

            var filteredPeople = peopleViewModel.People
                .Where(x => x.Name == searchString || x.City == searchString).ToList();
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
            peopleViewModel.People.RemoveAll(x => x.PersonId == id);

            return View("Index", peopleViewModel);

        }

        [HttpPost]
        public IActionResult AddPerson(PeopleViewModel p)
        {
            if (ModelState.IsValid)
            {
                peopleViewModel.People.Add(new PersonViewModel()
                {
                    PersonId = idCounter + 1,
                    Name = p.cpvm.Name,
                    City = p.cpvm.City,
                    PhoneNumber = p.cpvm.PhoneNumber
                });
                idCounter++;
            }
            else
            {
                var i = ModelState.ErrorCount;
            }


            return View("Index", peopleViewModel);
        }

    }
}

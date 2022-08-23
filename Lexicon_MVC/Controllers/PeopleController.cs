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

        [HttpPost]
        public IActionResult Delete(int id)
        {
          
            //ta bort personen med rätt id
            peopleViewModel.People.RemoveAll(x => x.PersonId == id);

            return View("Index",peopleViewModel);

        }

        [HttpPost]
        public IActionResult AddPerson(PeopleViewModel p)
        {
            if (ModelState.IsValid)
            {
                peopleViewModel.People.Add(new Person()
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

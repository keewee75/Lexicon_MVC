using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Lexicon_MVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Lexicon_MVC.Controllers
{
    public class AjaxController : Controller
    {
        public static PeopleViewModel peopleViewModel = new PeopleViewModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListPeople()
        {
            
            return PartialView("_ListPeople", peopleViewModel);
        }

        [HttpPost]
        public ActionResult PersonId(int id)
        {
            var personIdList = peopleViewModel.People
                .Where(x => x.PersonId == id).ToList();
            var m = new PeopleViewModel();
            m.People = personIdList;

            return PartialView("_ListPeople", m);
        }

        [HttpPost]
        public IActionResult PersonDelete(int id)
        {
            int count = peopleViewModel.People.Count();
            PeopleViewModel personIdList = new();
            personIdList.People = peopleViewModel.People
                .Where(x => x.PersonId == id).ToList();

            //ta bort personen med rätt id
            peopleViewModel.People.RemoveAll(x => x.PersonId == id);

            // Check if person was deleted
            if (count != peopleViewModel.People.Count)
            {
                peopleViewModel.deleteSuccess = true;
                peopleViewModel.personDeleted = personIdList.People[0].Name;
                ViewBag.Message = personIdList.People[0].Name + " Was deleted";
            }
            else
            {
                peopleViewModel.deleteSuccess = false;
                ViewBag.Message = "";
            }

            return PartialView("_ListPeople", peopleViewModel);

        }
    }

}

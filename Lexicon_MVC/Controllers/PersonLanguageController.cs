using Lexicon_MVC.Data;
using Lexicon_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_MVC.Controllers
{
    public class PersonLanguageController : Controller
    {
        readonly ApplicationDbContext _dbContext;
        public PersonLanguageController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Person> people = _dbContext.People.Include(p => p.Languages).ToList();
            return View(people);
        }
        public IActionResult AddLanguage()
        {
            ViewBag.People = new SelectList(_dbContext.People, "PersonId", "Name");
            ViewBag.Languages = new SelectList(_dbContext.Languages, "LanguageId", "LanguageName");
            return View();
        }
        [HttpPost]
        public IActionResult AddLanguage(int personId, int languageId)
        {
            if (ModelState.IsValid)
            {
                var person = _dbContext.People.FirstOrDefault(x => x.PersonId == personId);
                var language = _dbContext.Languages.FirstOrDefault(x => x.LanguageId == languageId);

                List<Person> people = _dbContext.People.Include(p => p.Languages).ToList();
                // Prevents duplicates to be inserted
                foreach (var pers in people)
                {
                    if (pers.PersonId == personId)
                    {
                        foreach (var lang in pers.Languages)
                        {
                            if (lang.LanguageId == languageId)
                            {
                                ViewBag.Exists = "Already exists";

                                return View("Index", people);
                            }
                        }
                    }

                }

                person.Languages.Add(language);
                _dbContext.SaveChanges();

            }

            return RedirectToAction("Index");
        }

        //public IActionResult EditLanguage()
        //{
        //    ViewBag.People = new SelectList(_dbContext.People, "PersonId", "Name");
        //    List<Person> people = _dbContext.People.Include(p => p.Languages).ToList();

        //    return View(people);
        //}
        //[HttpPost]
        //public IActionResult EditLanguage(int personId)
        //{
        //    ViewBag.People = new SelectList(_dbContext.People, "PersonId", "Name");
        //    List<Person> filteredPerson = _dbContext.People
        //        .Where(x => x.PersonId == personId).Include(p=> p.Languages).ToList();

        //    return View(filteredPerson);
        //}

        public IActionResult EditLanguage()
        {
            ViewBag.People = new SelectList(_dbContext.People, "PersonId", "Name");
            List<Language> language = _dbContext.Languages.Include(p => p.People).ToList();

            return View(language);
        }
        [HttpPost]
        public IActionResult EditLanguage(int languageId)
        {
            ViewBag.People = new SelectList(_dbContext.People, "PersonId", "Name");
            List<Language> filteredPerson = _dbContext.Languages
                .Where(x => x.LanguageId == languageId).Include(p => p.People).ToList();

            return View(filteredPerson);
        }

        public IActionResult Delete(int personId)
        {
            Person p = _dbContext.People.FirstOrDefault(x => x.PersonId == personId);
            List<Person> people = _dbContext.People.Include(p => p.Languages).ToList();
            foreach (var pers in people)
            {
                if (pers.PersonId == personId)
                {
                    foreach (var lang in pers.Languages)
                    {
                        if (lang.LanguageId > 0)
                        {
                            //var l = _dbContext.Languages.FirstOrDefault(x => x.LanguageId == lang.LanguageId);
                            p.Languages.Add(lang);

                        }
                    }
                }
            }
            return View(p);
        }

        [HttpPost]
        public IActionResult Delete(Person p, int languageId)
        {
            return RedirectToAction("Index");
        }
    }
}

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
                //var p = person.Languages(p => p.LanguageId == languageId);
                List<Language> AllLanguages = _dbContext.Languages.Include(p => p.People).ToList();
                foreach (var lang in AllLanguages)
                {
                    if (lang.LanguageId == languageId)
                    {
                        foreach (var pers in lang.People)
                        {
                            if (pers.PersonId == personId)
                            {
                                ViewBag.Exists = "Already exists";
                                List<Person> people = _dbContext.People.Include(p => p.Languages).ToList();
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
    }
}

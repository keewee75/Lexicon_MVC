using Lexicon_MVC.Data;
using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_MVC.Controllers
{
    public class PersonLanguageController : Controller
    {
        public static LanguageViewModel languageViewModel = new LanguageViewModel();
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

        public IActionResult AddNewLanguage()
        {
            
            ViewBag.Languages = new SelectList(_dbContext.Languages, "LanguageId", "LanguageName");
            languageViewModel.Languages = _dbContext.Languages.ToList();
            return View(languageViewModel);
        }

        [HttpPost]
        public IActionResult AddNewLanguage(Language language)
        {

            if (ModelState.IsValid)
            {
                _dbContext.Languages.Add(language);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteLanguage(int languageid)
        {
            var language = _dbContext.Languages.FirstOrDefault(x => x.LanguageId == languageid);

            _dbContext.Languages.Remove(language);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult AddLanguageToPerson()
        {
            ViewBag.People = new SelectList(_dbContext.People, "PersonId", "Name");
            ViewBag.Languages = new SelectList(_dbContext.Languages, "LanguageId", "LanguageName");
            return View();
        }
        [HttpPost]
        public IActionResult AddLanguageToPerson(int personId, int languageId)
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


        public IActionResult Delete(int personId)
        {
            Person p = _dbContext.People.FirstOrDefault(x => x.PersonId == personId);
            List<Person> people = _dbContext.People.Include(p => p.Languages).ToList();
            List<Language> knownLanguages = new List<Language>();
            foreach (var pers in people)
            {
                if (pers.PersonId == personId)
                {
                    foreach (var lang in pers.Languages)
                    {
                        if (lang.LanguageId > 0)
                        {

                            knownLanguages.Add(lang);

                        }
                    }
                }
            }
            p.Languages = knownLanguages;
            return View(p);
        }

        [HttpPost]
        public IActionResult Delete(int id, int languageId)
        {
            var lang = _dbContext.Languages.Include(g => g.People).Single(u => u.LanguageId == languageId);
            var pers = _dbContext.People.Single(u => u.PersonId == id);

            lang.People.Remove(lang.People.Where(ugu => ugu.PersonId == pers.PersonId).FirstOrDefault());
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}





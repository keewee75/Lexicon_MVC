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
            List<Person> people = _dbContext.People.Include(p=>p.Languages).ToList();
            return View(people);
        }
        public IActionResult AddPersonAndLanguage()
        {
            ViewBag.People = new SelectList(_dbContext.People, "PersonId", "Name");
            ViewBag.Languages = new SelectList(_dbContext.Languages, "LanguageId", "LanguageName");
            return View();
        }
        [HttpPost]
        public IActionResult AddPersonAndLanguage(int personId, int languageId)
        {
            var person = _dbContext.People.FirstOrDefault(x => x.PersonId == personId);
            var language = _dbContext.Languages.FirstOrDefault(x => x.LanguageId == languageId);

            person.Languages.Add(language);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

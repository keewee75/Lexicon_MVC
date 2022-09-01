using Lexicon_MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return View();
        }
        public IActionResult ShowPersonAndLanguage()
        {
            ViewBag.People = new SelectList(_dbContext.People, "PersonId", "Name");
            ViewBag.Languages = new SelectList(_dbContext.Languages, "LanguageId", "LanguageName");
            return View();
        }
        [HttpPost]
        public IActionResult ShowPersonAndLanguage(int personId, int languageId)
        {
            var person = _dbContext.People.FirstOrDefault(x => x.PersonId == personId);
            var language = _dbContext.Languages.FirstOrDefault(x => x.LanguageId == languageId);

            person.Languages.Add(language);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

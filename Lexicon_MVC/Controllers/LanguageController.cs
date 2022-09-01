using Microsoft.AspNetCore.Mvc;

namespace Lexicon_MVC.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

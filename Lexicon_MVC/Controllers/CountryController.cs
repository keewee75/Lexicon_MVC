using Microsoft.AspNetCore.Mvc;

namespace Lexicon_MVC.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

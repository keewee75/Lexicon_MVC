using Microsoft.AspNetCore.Mvc;
using Lexicon_MVC.Models;

namespace Lexicon_MVC.Controllers
{
    public class DoctorController : Controller
    {
        static string message = "Check your temperature :";

        public IActionResult Index()
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int? temp)
        {
            if (temp != null)
            {
                ViewBag.Temperature = Utilities.FeverCheck(temp);
            }
            else
            {
                ViewBag.Message = message;
            }
            return View();
        }

    }
}

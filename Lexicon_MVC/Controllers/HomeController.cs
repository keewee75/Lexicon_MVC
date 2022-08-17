using Lexicon_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lexicon_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GuessingGame()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("GuessSession")))
            {
                ViewBag.Message = "New Random number is set and saved in session!";
                Utilities.RandomizeNumber();
                HttpContext.Session.SetString("GuessSession", Utilities.RandomNumber.ToString());
                ViewBag.NumberToGuess = HttpContext.Session.GetString("GuessSession");
            }
            else
            {
                ViewBag.Message = "GuessSession is already set!";
                
            }
            return View();
        }
        public IActionResult AboutMe()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int? input)
        {
            if (input != null)
            {
                ViewBag.Message = Utilities.GuessNumber(input);
                ViewBag.Count = Utilities.GuessCount;
            }
            else
            {
                ViewBag.Message = "No number guessed!";
            }
            return View();
        }
    }
}

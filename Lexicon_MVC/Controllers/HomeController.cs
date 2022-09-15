using Lexicon_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lexicon_MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly RoleManager<IdentityRole> roleManager;
        readonly UserManager<ApplicationUser> userManager;

        public HomeController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
		{
			this.roleManager = roleManager;
			this.userManager = userManager;
		}

		public IActionResult Index()
        {
            if (!String.IsNullOrEmpty(User.Identity.Name))
			{
                var user = userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

				ViewData["fullname"] = user.FirstName + " " + user.LastName;
			}
            return View();
        }
        public IActionResult GuessingGame()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("GuessSession")))
            {
                ViewBag.Message = "A new Random number is set and saved in session!";
                Utilities.RandomizeNumber();
                HttpContext.Session.SetString("GuessSession", Utilities.RandomNumber.ToString());
                ViewBag.NumberToGuess = HttpContext.Session.GetString("GuessSession");
            }
            else
            {
                //ViewBag.Message = "GuessSession is already set!";
                ViewBag.Count = Utilities.GuessCount;

            }
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int? input)
        {
            if (input == Utilities.RandomNumber)
            {
                ViewBag.Message = Utilities.GuessNumber(input);
                HttpContext.Session.Remove("GuessSession");
                Utilities.GuessCount = 0;
                ViewBag.EndMessage = "End";
            }
            else if (input != null)
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

    }
}

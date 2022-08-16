using Microsoft.AspNetCore.Mvc;

namespace Lexicon_MVC.Controllers
{
    public class DoctorController : Controller
    {

        public IActionResult Index()
        {
            //ViewBag.Temperature = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(int Temp)
        {
            var cold = "°C, You are ice cold !";
            var fever = "°C, You got a fever !";
            var okay = "°C, You are OK !";
            if (Temp < 37)
            {
                ViewBag.Temperature = Temp + cold;              
            }
            else if (Temp > 37)
            {
                ViewBag.Temperature = Temp + fever;   
            }
            else
            {
                ViewBag.Temperature = Temp + okay;               
            }
            return View();
        }

    }
}

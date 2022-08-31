using Lexicon_MVC.Data;
using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_MVC.Controllers
{
    public class CityController : Controller
    {
        public static CityViewModel cityViewModel = new CityViewModel();
        readonly ApplicationDbContext? _dbContext; // creates a readonly of DbContext

        public CityController(ApplicationDbContext? dbContext) // Adds a context to a constructor
        {
            _dbContext = dbContext; // Initiates the value
        }

        public IActionResult Index()
        {

            List<City> listOfCities = _dbContext.Cities.ToList();

            return View(listOfCities);
        }
    }
}

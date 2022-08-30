using Lexicon_MVC.Data;
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
            cityViewModel.Cities = _dbContext.Cities.Include(c => c.Country).ToList(); // Includes also countries

            return View(cityViewModel);
        }
    }
}

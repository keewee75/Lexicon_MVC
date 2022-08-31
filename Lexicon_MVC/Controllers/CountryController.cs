using Lexicon_MVC.Data;
using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lexicon_MVC.Controllers
{
    public class CountryController : Controller
    {
        public static CountryViewModel countryViewModel = new CountryViewModel();
        readonly ApplicationDbContext? _dbContext; // creates a readonly of DbContext

        public CountryController(ApplicationDbContext? dbContext) // Adds a context to a constructor
        {
            _dbContext = dbContext; // Initiates the value
        }

        public IActionResult Index()
        {
            
            
            
            ViewBag.CityNames = new SelectList(_dbContext.Cities, "CityId", "CityName");
            return View(_dbContext.Countries.Include(p => p.Cities).ToList());
        }
    }
}

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

            List<Country> listOfCountries = _dbContext.Countries.ToList();

            return View(listOfCountries);
        }

        public IActionResult Create()
        {
            ViewBag.Countries = new SelectList(_dbContext.Countries, "CountryId", "CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            
            if (ModelState.IsValid)
            {
                _dbContext.Countries.Add(country);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int countryid)
        {
            var country = _dbContext.Countries.FirstOrDefault(x=>x.CountryId == countryid);
            return View(country);
        }

        [HttpPost]
        public IActionResult Edit(Country country)
        {
            _dbContext.Update(country);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int countryid)
        {
            var country = _dbContext.Countries.FirstOrDefault(x => x.CountryId == countryid);

            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

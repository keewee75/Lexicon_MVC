using Lexicon_MVC.Data;
using Lexicon_MVC.Models;
using Lexicon_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Create()
        {
            ViewBag.Countries = new SelectList(_dbContext.Countries, "CountryId", "CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            ModelState.Remove("Country");
            if (ModelState.IsValid)
            {
                _dbContext.Cities.Add(city);
                _dbContext.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int cityid)
        {
            ViewBag.Countries = new SelectList(_dbContext.Countries, "CountryId", "CountryName");
            var city = _dbContext.Cities.FirstOrDefault(x => x.CityId == cityid);
            CityViewModel m = new CityViewModel();
            m.CityId = city.CityId;
            m.CountryId = city.CountryId;
            m.CityName = city.CityName;
            m.Countries = _dbContext.Countries.ToList();
            return View(m);
        }

        [HttpPost]
        public IActionResult Edit (CityViewModel m, int countryId)
        {
            City p = new City();
            p.CityId = m.CityId;
            p.CountryId = countryId;
            p.CityName = m.CityName;
            _dbContext.Update(p);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int cityid)
        {
            var city = _dbContext.Cities.FirstOrDefault(x=>x.CityId == cityid);

            _dbContext.Cities.Remove(city);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

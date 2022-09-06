using Lexicon_MVC.Models;

namespace Lexicon_MVC.ViewModels
{
    public class CityViewModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public List<City> Cities  { get; set; } = new List<City>();
        public List<Country> Countries { get; set; } = new List<Country>();

    }
}

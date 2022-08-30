using Lexicon_MVC.Models;

namespace Lexicon_MVC.ViewModels
{
    public class CityViewModel
    {
        public List<City> Cities  { get; set; }

        public CityViewModel()
        {
            Cities = new List<City>();
        }
            
    }
}

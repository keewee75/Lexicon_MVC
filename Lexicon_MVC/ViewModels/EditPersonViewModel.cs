using Lexicon_MVC.Models;

namespace Lexicon_MVC.ViewModels
{
    public class EditPersonViewModel
    {
            public int? PersonId { get; set; }

            public string? Name { get; set; }

            public string? PhoneNumber { get; set; }

            //public City City { get; set; }
            public int CityId { get; set; }
            public List<City> Cities { get; set; } = new List<City>();

        
    }
}

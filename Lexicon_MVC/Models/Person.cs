using System.ComponentModel.DataAnnotations;

namespace Lexicon_MVC.Models
{
    public class Person
    {
      
        public int? PersonId { get; set; }
 
        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }
        public List<Language> People { get; set; } = new List<Language>();

    }
}

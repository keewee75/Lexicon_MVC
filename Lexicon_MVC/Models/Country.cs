﻿namespace Lexicon_MVC.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public ICollection<City> Cities { get; set; }
        
    }
}

using Lexicon_MVC.Models;

namespace Lexicon_MVC.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; }

        public CreatePersonViewModel cpvm { get; set; }

    public PeopleViewModel()
        {
            People = new List<Person>();
            People.Add(new Person()
            {
                PersonId = 1,
                Name = "Kalle",
                City = "Stockhom",
                PhoneNumber = "+46 080808"
            });

            People.Add(new Person()
            {
                PersonId = 2,
                Name = "Marko",
                City = "Gothenburg",
                PhoneNumber = "+46 031031"
            });

            People.Add(new Person()
            {
                PersonId = 3,
                Name = "Olle",
                City = "Malmö",
                PhoneNumber = "+46 040040"
            });
            cpvm = new CreatePersonViewModel();

        }
    }
}

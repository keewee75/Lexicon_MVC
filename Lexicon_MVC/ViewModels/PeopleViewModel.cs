using Lexicon_MVC.Models;

namespace Lexicon_MVC.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; }

        public CreatePersonViewModel cpvm { get; set; }
        public bool deleteSuccess { get; set; } = false;
        public string personDeleted { get; set; } = "";

    public PeopleViewModel()
        {
            People = new List<Person>();
            People.Add(new Person()
            {
                PersonId = 1,
                Name = "Kalle",
                City = "Stockholm",
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
                Name = "Emil",
                City = "Gothenburg",
                PhoneNumber = "+46 031032"
            });

            People.Add(new Person()
            {
                PersonId = 4,
                Name = "Olle",
                City = "Malmö",
                PhoneNumber = "+46 040040"
            });
            cpvm = new CreatePersonViewModel();

        }
    }
}

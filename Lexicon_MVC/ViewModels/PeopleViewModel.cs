using Lexicon_MVC.Models;

namespace Lexicon_MVC.ViewModels
{
    public class PeopleViewModel
    {
        public List<PersonViewModel> People { get; set; }

        public CreatePersonViewModel cpvm { get; set; }

    public PeopleViewModel()
        {
            People = new List<PersonViewModel>();
            People.Add(new PersonViewModel()
            {
                PersonId = 1,
                Name = "Kalle",
                City = "Stockholm",
                PhoneNumber = "+46 080808"
            });

            People.Add(new PersonViewModel()
            {
                PersonId = 2,
                Name = "Marko",
                City = "Gothenburg",
                PhoneNumber = "+46 031031"
            });

            People.Add(new PersonViewModel()
            {
                PersonId = 3,
                Name = "Emil",
                City = "Gothenburg",
                PhoneNumber = "+46 031032"
            });

            People.Add(new PersonViewModel()
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

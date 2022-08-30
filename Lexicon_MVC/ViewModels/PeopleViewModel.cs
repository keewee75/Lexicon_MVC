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

            cpvm = new CreatePersonViewModel();

        }
    }
}

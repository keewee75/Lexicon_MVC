namespace Lexicon_MVC.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
    }
}

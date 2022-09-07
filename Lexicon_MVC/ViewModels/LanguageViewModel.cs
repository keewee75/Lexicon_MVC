using Lexicon_MVC.Models;

namespace Lexicon_MVC.ViewModels
{
    public class LanguageViewModel
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}

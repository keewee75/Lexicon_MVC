using System.ComponentModel.DataAnnotations;

namespace Lexicon_MVC.ViewModels
{
    public class CreatePersonViewModel
    {
       
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        [Display(Name = "Phone")]
        [Required]
        [StringLength (10)]
        public string? PhoneNumber { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace BookWiki.ViewModels
{
    public class CreateAutorViewModel
    {
        [Required]
        [Display(Name="Autor Name")]
        public string Name {get;set;}
    }
}
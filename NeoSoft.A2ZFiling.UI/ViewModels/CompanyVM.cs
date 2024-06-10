using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class CompanyVM
    {        
        public int CompanyId { get; set; }
        [Required(ErrorMessage ="Company Name is required")]        
        public string CompanyName { get; set;}
        [Required]
        public string ShortName { get; set;}

        //[Required]
        public bool IsActive { get; set; }
    }
}

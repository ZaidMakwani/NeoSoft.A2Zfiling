using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class CreateCompanyVM
    {
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
    }
}

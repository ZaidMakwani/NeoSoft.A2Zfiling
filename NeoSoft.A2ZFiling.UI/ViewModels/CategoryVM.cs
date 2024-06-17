using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }


        [Required]
        [MaxLength(500)]
        public string CategoryName { get; set; }


        [Required]
        [MaxLength(500)]
        public string ShortName { get; set; }

        public bool IsActive { get; set; }
    }
}

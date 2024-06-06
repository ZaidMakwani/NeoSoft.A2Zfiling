using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class IndustryVM
    {
        public int IndustryId { get; set; }
        [Required]
        public string IndustryName { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}

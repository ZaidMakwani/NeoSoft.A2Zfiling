using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class LicenseTypeVM
    {
        public int LicenseTypeId { get; set; }

        [Required]
        [MaxLength(500)]
        public string LicenseName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}

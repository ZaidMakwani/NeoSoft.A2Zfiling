using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.Models
{
    public class ZoneVM
    {
        public int ZoneId { get; set; }

        [Required(ErrorMessage ="Zone Name is required")]
        public string ZoneName { get; set; }

        public bool IsActive { get; set; }
    }
}

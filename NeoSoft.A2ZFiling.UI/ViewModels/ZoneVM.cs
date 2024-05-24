using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class ZoneVM
    {
        //ghjfkj
        public int ZoneId { get; set; }

        [Required(ErrorMessage = "Zone Name is required")]
        public string ZoneName { get; set; }

        public bool IsActive { get; set; }
    }
}

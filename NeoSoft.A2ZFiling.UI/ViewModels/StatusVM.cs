using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class StatusVM
    {

        public int StatusId { get; set; }

        [Required(ErrorMessage ="Status Name is Required")]
        [MaxLength(500)]
        public string StatusName { get; set; }

        public bool IsActive { get; set; }
    }
}

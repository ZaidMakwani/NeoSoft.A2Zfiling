using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class StateVM
    {
        public int StateId { get; set; }
        [Required]
        //[DisplayName("State Name")]

        public string StateName { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}

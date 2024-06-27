using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class PinCodeVM
    {

        public int PinCodeId { get; set; }
        //[Required(ErrorMessage = "Pincode number is required")]
        public long PinCodeNumber { get; set; }
        public bool IsActive { get; set; }
    }
}

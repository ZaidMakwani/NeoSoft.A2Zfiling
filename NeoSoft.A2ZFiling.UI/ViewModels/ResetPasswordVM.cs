using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "New Password is required")]
        public string newPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        public string confirmPassword { get; set; }
        public string UserId { get; set; }
    }
}

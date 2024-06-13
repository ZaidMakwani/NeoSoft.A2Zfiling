namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class AppUserVM
    {
        public string? AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public long ContactNumber { get; set; }
        public string Address { get; set; }
        public string? Role { get; set; }
        public string PasswordCurr { get; set; }
        public string? ProfileImagePath { get; set; }

        [Required(ErrorMessage = "Current password is required")]
        public string? CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}

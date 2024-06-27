using System.ComponentModel.DataAnnotations;



namespace NeoSoft.A2ZFiling.UI.ViewModels

{
    public class AppUserVM
    {
        public string? AppUserId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must contain only alphabetic characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must contain only alphabetic characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [Range(1000000000, 9999999999, ErrorMessage = "Contact number must be a valid 10-digit number")]
        public long ContactNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string Address { get; set; }

        public string? Role { get; set; }

        [Required(ErrorMessage = "Current password is required")]
        [DataType(DataType.Password)]
        public string PasswordCurr { get; set; }
        public string? ProfileImagePath { get; set; }

        [Required(ErrorMessage = "Current password is required")]
        public string? CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
        public string? Id { get; set; }
    }
}

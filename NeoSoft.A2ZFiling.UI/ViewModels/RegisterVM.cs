using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only alphabetic characters are allowed")]
        [StringLength(30, ErrorMessage = "First Name must not exceed 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only alphabetic characters are allowed")]
        [StringLength(30, ErrorMessage = "Last Name must not exceed 30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed")]
        [StringLength(30, ErrorMessage = "UserName must not exceed 30 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(50, ErrorMessage = "Email must not exceed 50 characters")]
        public string Email { get; set; }
                        
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 10 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid contact number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only alphabetic characters are allowed")]
        [StringLength(300, ErrorMessage = "Address must not exceed 300 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Select valid option")]
        public int RoleId { get; set; }

        public IFormFile ProfilePicture { get; set; }
        public string? ProfileImagePath { get; set; }
    }
}

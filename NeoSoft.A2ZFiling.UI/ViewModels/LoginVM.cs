using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NeosoftA2Zfilings.Views.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(20)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(20, ErrorMessage = "Max password length is 20 characters.")]
        [MinLength(3, ErrorMessage = "Minimum password length is 3 characters.")]
        [PasswordPropertyText]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
       public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? Expiration { get; set; }
    }
}

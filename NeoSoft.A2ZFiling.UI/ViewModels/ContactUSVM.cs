using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class ContactUSVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Your Name is required")]
        public string YourName { get; set; }

        [Required(ErrorMessage = "Your Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string YourEmail { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
    }
}

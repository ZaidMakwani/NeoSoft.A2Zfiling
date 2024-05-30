using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NeosoftA2Zfilings.Views.ViewModels
{
    public class RoleVM
    {
        [Required(ErrorMessage = "RoleId is required")]

        public int RoleId { get; set; }




        [Required(ErrorMessage = "Name is required")]

        public string RoleName { get; set; }

        public bool IsActive { get; set; }
    }
}

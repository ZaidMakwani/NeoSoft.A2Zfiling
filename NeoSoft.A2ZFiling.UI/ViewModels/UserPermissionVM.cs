using NeoSoft.A2Zfiling.Domain.Entities;
using NeosoftA2Zfilings.Views.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class UserPermissionVM
    {
        public int UserPermissionId { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string RoleName { get; set; }


        public int PermissionId { get; set; }

        public string ControllerName { get; set; }

        public string ActionName {  get; set; }
 
        public bool IsActive { get; set; }

        public List<PermissionVM> Permissions { get; set; }

        public List<PermissionVM> Actions { get; set; }

        [Required(ErrorMessage = "At least one permission must be selected")]
        public List<int> SelectedPermissions { get; set; } = new List<int>();






    }
}

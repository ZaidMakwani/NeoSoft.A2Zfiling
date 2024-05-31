using System.ComponentModel.DataAnnotations.Schema;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class UserPermissionVM
    {
        public int UserPermissionId { get; set; }


        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public int PermissionId { get; set; }

        public string ControllerName { get; set; }

        public string ActionName {  get; set; }

        public bool IsActive { get; set; }
    }
}

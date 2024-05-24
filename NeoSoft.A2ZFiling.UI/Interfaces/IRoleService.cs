using NeoSoft.A2Zfiling.Domain.Entities;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleVM>> GetRolesAsync();
        Task<RoleVM> CreateRoleAsync(RoleVM role); 
       // Task<RoleVM> GetRoleByIdAsync(int id);
        Task<RoleVM> UpdateRoleAsync(RoleVM role);
        Task<string> DeleteRoleAsync(int id);
    }
}

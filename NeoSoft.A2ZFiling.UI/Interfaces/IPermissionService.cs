using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IPermissionService
    {
        Task<IEnumerable<PermissionVM>> GetPermissionAsync();

        Task<PermissionVM> CreatePermissionAsync(PermissionVM role);

        Task<PermissionVM> GetByIdAsync(int id);
        Task<PermissionVM> UpdatePermissionAsync(PermissionVM role);

        Task<PermissionVM> DeletePermissionAsync(int id);
    }
}

using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IUserPermission
    {
        Task<IEnumerable<UserPermissionVM>> GetUserPermissionAsync();

        Task<UserPermissionVM> CreateUserPermissionAsync(UserPermissionVM role);

        Task<UserPermissionVM> GetByIdAsync(int id);

        Task<UserPermissionVM> UpdateUserPermissionAsync(UserPermissionVM role);

        Task<UserPermissionVM> DeleteUserPermissionAsync(int id);
    }
}

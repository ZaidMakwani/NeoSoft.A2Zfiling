using NeoSoft.A2ZFiling.UI.ViewModels;
using System.Security.Claims;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IPermissionService
    {
        Task<IEnumerable<PermissionVM>> GetPermissionAsync();

        Task<PermissionVM> CreatePermissionAsync(PermissionVM role, string UserId);

        Task<PermissionVM> GetByIdAsync(int id);
        Task<PermissionVM> UpdatePermissionAsync(PermissionVM role);

        Task<PermissionVM> DeletePermissionAsync(int id);

       
    }

   
    }


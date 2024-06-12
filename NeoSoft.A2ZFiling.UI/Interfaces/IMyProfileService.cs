using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IMyProfileService
    {
        Task<AppUserVM> GetAccountDetailsAsync(string Id);
        Task<AppUserVM> UpdateAccountDetailsAsync(AppUserVM model);
        Task<AppUserVM> UpdatePassword(string UserId, string confirmPassword);
    }
}

using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IUserInfoService
    {
        Task<AppUserVM> GetUserIdByEmailAsync(string email);
    }
}

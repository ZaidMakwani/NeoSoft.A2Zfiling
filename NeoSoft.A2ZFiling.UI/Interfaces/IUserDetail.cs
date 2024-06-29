using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IUserDetail
    {
        Task<UserDetailVM> CreateUserDetailAsync(UserDetailVM role);
    }
}

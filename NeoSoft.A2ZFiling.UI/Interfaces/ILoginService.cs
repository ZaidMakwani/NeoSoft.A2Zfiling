using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface ILoginService
    {
        Task<LoginVM> LoginAsync(LoginVM loginvm);
    }
}

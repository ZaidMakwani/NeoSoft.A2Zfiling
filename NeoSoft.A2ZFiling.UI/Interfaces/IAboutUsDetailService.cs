using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
   public interface  IAboutUsDetailService
    {
        Task<AboutVM> AboutUsDetailAsync(AboutVM registerVM);
        Task<AboutVM> GetAboutUsDetailAsync();
    }
}

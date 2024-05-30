using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IRegisterService
    {
        Task<RegisterVM> RegisterAsync(RegisterVM registervm);
    }
}

using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface ITermsAndConditionsServices
    {
        Task<TermsAndConditionsVM> TermsAndConditionsAsync(TermsAndConditionsVM registerVM);
        Task<TermsAndConditionsVM> GetTermsAndConditionsAsync();

    }
}

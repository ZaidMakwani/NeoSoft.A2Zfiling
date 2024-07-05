using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IFAQService
    {
        Task<FAQVM> FAQAsync(FAQVM registerVM);
        Task<FAQVM> GetFAQAsync();
    }
}

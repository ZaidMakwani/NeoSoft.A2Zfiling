using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IIndustryService
    {
        IEnumerable<IndustryVM> GetIndustryAsync();
        HttpResponseMessage CreateIndustryAsync(IndustryVM role);
        //Task<IndustryVM> UpdateIndustryAsync(IndustryVM role);

        //Task<IndustryVM> DeleteIndustryAsync(int id);

        //Task<IndustryVM> GetByIdAsync(int id);

        //Task<IndustryVM> GetIndustryByNameAsync(string IndustryName);
    }
}

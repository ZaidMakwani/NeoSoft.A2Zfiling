using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IFormService
    {
        Task<IEnumerable<ContactUSVM>> GetFormAsync();
        //Task<IEnumerable<ContactUSVM>> GetFormAsync(int id);
        Task<ContactUSVM> CreateFormAsync(ContactUSVM role);
        Task<ContactUSVM> DeleteFormAsync(int id);

        Task<ContactUSVM> GetByIdAsync(int id);
        Task<ContactUSVM> UpdateFormAsync(ContactUSVM role);

    }
}

using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryVM>> GetCategoryAsync();
        Task<CategoryVM> CreateCategoryAsync(CategoryVM role);


        Task<CategoryVM> DeleteCategoryAsync(int id);

        Task<CategoryVM> GetByIdAsync(int id);

        Task<CategoryVM> UpdateCategoryAsync(CategoryVM role);
    }
}

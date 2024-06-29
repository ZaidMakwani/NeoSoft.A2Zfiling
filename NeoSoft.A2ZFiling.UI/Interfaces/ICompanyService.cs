using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
	public interface ICompanyService
	{
		Task<CompanyVM> CreateCompanyAsync(CompanyVM model);
		Task<CompanyVM> DeleteCompanyAsync(int id);
		Task<CompanyVM> GetByIdAsync(int id);
		Task<IEnumerable<CompanyVM>> GetCompanyAsync();
		Task<CompanyVM> UpdateCompanyAsync(CompanyVM role);
	}
}

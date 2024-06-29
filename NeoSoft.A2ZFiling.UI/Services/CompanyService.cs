using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
	public class CompanyService : ICompanyService
	{
		private readonly IApiClient<CompanyVM> _apiClient;
		private readonly ILogger<CompanyService> _logger;

		public CompanyService(IApiClient<CompanyVM> apiClient, ILogger<CompanyService> logger)
		{
			_apiClient = apiClient;
			_logger = logger;
		}

		public async Task<CompanyVM> CreateCompanyAsync(CompanyVM model)
		{
			_logger.LogInformation("Create CompanyService Initiated");
			var data = await _apiClient.PostAsync("AddCompany/", model);
			_logger.LogInformation("Create CompanyService Completed");
			return data.Data;
		}

		public async Task<CompanyVM> DeleteCompanyAsync(int id)
		{
			_logger.LogInformation("Delete CompanyService Initiated");

			var getById = await _apiClient.GetByIdAsync($"DeleteCompany/id?id={id}");
			if (getById == null)
			{
				_logger.LogError("Company not found.");
				return null;
			}
			var Company = getById.Data;
		Company.IsActive = false;
			var updatedata = await _apiClient.PutAsync("Company/id", Company);
			_logger.LogInformation("Delete CompanyService Completed");

			return updatedata.Data;
		}

		public async Task<CompanyVM> GetByIdAsync(int id)
		{
			_logger.LogInformation("GetById CompanyService Initiated");
			var Company = await _apiClient.GetByIdAsync($"GetCompaniesById/id?id={id}");
			_logger.LogInformation("GetById CompanyService Completed");
			return Company.Data;
		}

		public async Task<IEnumerable<CompanyVM>> GetCompanyAsync()
		{
			_logger.LogInformation("GetAll CompanyService Initiated");
			var zones = await _apiClient.GetAllAsync("GetAllCompanies/all");
			_logger.LogInformation("GetAll CompanyService Completed");

			return zones.Data;
		}

		public async Task<CompanyVM> UpdateCompanyAsync(CompanyVM role)
		{
			_logger.LogInformation("Update CompanyService Initiated");
			var Company = await _apiClient.PutAsync("UpdateCompany/", role);
			_logger.LogInformation("Update CompanyService Completed");
			return Company.Data;
		}
	}
}

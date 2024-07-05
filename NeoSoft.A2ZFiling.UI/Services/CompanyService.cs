<<<<<<< HEAD
﻿using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;

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
		var data = await _apiClient.PostAsync("Company/Create", model);
		_logger.LogInformation("Create CompanyService Completed");
		return data.Data;
	}

	public async Task<CompanyVM> DeleteCompanyAsync(int id)
	{
		_logger.LogInformation("Delete CompanyService Initiated");

		var getById = await _apiClient.GetByIdAsync($"Company/GetCompaniesById/Id?Id={id}");
		if (getById == null)
		{
			_logger.LogError("Company not found.");
			return null;
		}
		var Company = getById.Data;
		Company.IsActive = false;
		var updatedata = await _apiClient.PutAsync("Company/Update", Company);
		_logger.LogInformation("Delete CompanyService Completed");

		return updatedata.Data;
	}

	public async Task<CompanyVM> GetByIdAsync(int id)
	{
		_logger.LogInformation("GetById CompanyService Initiated");
		var Company = await _apiClient.GetByIdAsync($"Company/GetCompaniesById/Id?Id={id}");
		_logger.LogInformation("GetById CompanyService Completed");
		return Company.Data;
	}

	public async Task<IEnumerable<CompanyVM>> GetCompanyAsync()
	{
		_logger.LogInformation("GetAll CompanyService Initiated");
		var zones = await _apiClient.GetAllAsync("Company/GetAllCompanies/all");
		_logger.LogInformation("GetAll CompanyService Completed");
		return zones.Data;
	}



	public async Task<CompanyVM> UpdateCompanyAsync(CompanyVM role)
	{
		_logger.LogInformation("Update CompanyService Initiated");
		var Company = await _apiClient.PutAsync("Company/Update", role);
		_logger.LogInformation("Update CompanyService Completed");
		return Company.Data;
	}
}
=======
﻿using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeoSoft.A2ZFiling.UI.Interfaces;

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
            var data = await _apiClient.PostAsync("Company/Create", model);
            _logger.LogInformation("Create CompanyService Completed");
            return data.Data;
        }

        public async Task<CompanyVM> DeleteCompanyAsync(int id)
        {
            _logger.LogInformation("Delete CompanyService Initiated");

            var getById = await _apiClient.GetByIdAsync($"Company/GetCompaniesById/Id?Id={id}");
            if (getById == null)
            {
                _logger.LogError("Company not found.");
                return null;
            }
            var Company = getById.Data;
            Company.IsActive = false;
            var updatedata = await _apiClient.PutAsync("Company/Update", Company);
            _logger.LogInformation("Delete CompanyService Completed");

            return updatedata.Data;
        }

        public async Task<CompanyVM> GetByIdAsync(int id)
        {
            _logger.LogInformation("GetById CompanyService Initiated");
            var Company = await _apiClient.GetByIdAsync($"Company/GetCompaniesById/Id?Id={id}");
            _logger.LogInformation("GetById CompanyService Completed");
            return Company.Data;
        }

        public async Task<IEnumerable<CompanyVM>> GetCompanyAsync()
        {
            _logger.LogInformation("GetAll CompanyService Initiated");
            var zones = await _apiClient.GetAllAsync("Company/GetAllCompanies/all");
            _logger.LogInformation("GetAll CompanyService Completed");
            return zones.Data;
        }

        public async Task<CompanyVM> UpdateCompanyAsync(CompanyVM role)
        {
            _logger.LogInformation("Update CompanyService Initiated");
            var Company = await _apiClient.PutAsync("Company/Update", role);
            _logger.LogInformation("Update CompanyService Completed");
            return Company.Data;
        }
    }
}
>>>>>>> origin/development-mayur

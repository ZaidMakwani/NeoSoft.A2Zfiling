using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class LicenseService : ILicenseService
    {
        private readonly IApiClient<LicenseVM> _httpClient;
        private readonly ILogger<LicenseService> _logger;

        public LicenseService(IApiClient<LicenseVM> httpClient, ILogger<LicenseService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<LicenseVM> CreateLicenseAsync(LicenseVM role)
        {
            try
            {
                _logger.LogInformation("CreateLicense Service Initiated");
                var license = await _httpClient.PostAsync("License/", role);
                _logger.LogInformation("CreateLicense Service Initiated");
                return license.Data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An error occurred while creating the license");
                throw ex;
            }
        }

        public async Task<LicenseVM> DeleteLicenseAsync(int id)
        {
            try
            {
                _logger.LogInformation("DeleteLicense Service Initiated");
                var getById = await _httpClient.GetByIdAsync($"License/id?id={id}");
                if (getById == null)
                {
                    _logger.LogError("License not found.");
                    return null;
                }
                var licenseData = getById.Data;
                licenseData.IsActive = false;
                var updatedata = await _httpClient.PutAsync($"License/id?id={id}", licenseData);
                _logger.LogInformation("DeleteLicense Service Completed");
                return updatedata.Data;

            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data ");
                throw ex;
            }
        }

        public async Task<LicenseVM> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetLicenseId Service Initiated");
                var license = await _httpClient.GetByIdAsync($"License/id?id={id}");
                _logger.LogInformation("GetLicenseId Service Completed");
                return license.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data ");
                throw ex;
            }
        }

        public async Task<IEnumerable<LicenseVM>> GetLicenseAsync()
        {
            try
            {
                _logger.LogInformation("GetLicense Service Initiated");
                var license = await _httpClient.GetAllAsync("License/all");
                _logger.LogInformation("GetLicense Service Completed");
                return license.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while retrieving the data ");
                throw ex;
            }
        }

        public async Task<LicenseVM> UpdateLicenseAsync(LicenseVM role)
        {
            try
            {
                _logger.LogInformation("UpdateLicense Service Initiated");
                var license = await _httpClient.PutAsync("License/id", role);
                _logger.LogInformation("UpdateLicense Service Initiated");
                return license.Data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An error occurred while updating the license");
                throw ex;
            }
        }
    }
}

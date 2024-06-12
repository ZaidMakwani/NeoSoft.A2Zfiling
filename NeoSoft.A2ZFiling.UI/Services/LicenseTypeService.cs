using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class LicenseTypeService : ILicenseType
    {
        private readonly IApiClient<LicenseTypeVM> _httpClient;
        private readonly ILogger<LicenseTypeService> _logger;

        public LicenseTypeService(IApiClient<LicenseTypeVM> httpClient, ILogger<LicenseTypeService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<LicenseTypeVM> CreateLicenseTypeAsync(LicenseTypeVM role)
        {
            _logger.LogInformation("Create LicenseTypeService Initiated");
            var data = await _httpClient.PostAsync("LicenseType/", role);
            _logger.LogInformation("Create LicenseTypeService Completed");
            return data.Data;
        }

        public async Task<LicenseTypeVM> DeleteLicenseTypeAsync(int id)
        {
            _logger.LogInformation("Delete LicenseTypeService Initiated");

            var getById = await _httpClient.GetByIdAsync($"LicenseType/id?id={id}");
            if (getById == null)
            {
                _logger.LogError("License Type not found.");
                return null;
            }
            var license = getById.Data;
            license.IsActive = false;
            var updatedata = await _httpClient.PutAsync($"LicenseType/id?id={id}", license);
            _logger.LogInformation("Delete LicenseTypeService Completed");

            return updatedata.Data;
        }

        public async Task<LicenseTypeVM> GetByIdAsync(int id)
        {
            _logger.LogInformation("GetById LicenseTypeService Initiated");
            var license = await _httpClient.GetByIdAsync($"LicenseType/id?id={id}");
            _logger.LogInformation("GetById LicenseTypeService Completed");
            return license.Data;
        }

        public async Task<IEnumerable<LicenseTypeVM>> GetLicenseTypeAsync()
        {
            _logger.LogInformation("GetAll LicenseTypeService Initiated");
            var license = await _httpClient.GetAllAsync("LicenseType/all");
            _logger.LogInformation("GetAll LicenseTypeService Completed");

            return license.Data;
        }

        public async Task<LicenseTypeVM> UpdateLicenseTypeAsync(LicenseTypeVM role)
        {

            _logger.LogInformation("Update LicenseTypeService Initiated");
            var city = await _httpClient.PutAsync("LicenseType/id", role);
            _logger.LogInformation("Update LicenseTypeService Completed");
            return city.Data;
        }
    }
}

using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class CityService:ICityService
    {
        private readonly IApiClient<CityVM> _apiClient;
        private readonly ILogger<CityService> _logger;

        public CityService(IApiClient<CityVM> apiClient, ILogger<CityService> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task<CityVM> CreateCityAsync(CityVM model)
        {
            _logger.LogInformation("Create CitService Initiated");
            var data = await _apiClient.PostAsync("City/", model);
            _logger.LogInformation("Create CityService Completed");
            return data.Data;
        }

        public async Task<CityVM> DeleteCityAsync(int id)
        {
            _logger.LogInformation("Delete CityService Initiated");

            var getById = await _apiClient.GetByIdAsync($"City/id?id={id}");
            if (getById == null)
            {
                _logger.LogError("City not found.");
                return null;
            }
            var city = getById.Data;
            city.IsActive = false;
            var updatedata = await _apiClient.PutAsync("City/id", city);
            _logger.LogInformation("Delete CityService Completed");

            return updatedata.Data;
        }

        public async Task<CityVM> GetByIdAsync(int id)
        {
            _logger.LogInformation("GetById CityService Initiated");
            var city = await _apiClient.GetByIdAsync($"City/id?id={id}");
            _logger.LogInformation("GetById CityService Completed");
            return city.Data;
        }

        public async Task<IEnumerable<CityVM>> GetCityAsync()
        {
            _logger.LogInformation("GetAll CityService Initiated");
            var zones = await _apiClient.GetAllAsync("City/all");
            _logger.LogInformation("GetAll CityService Completed");

            return zones.Data;
        }

        public async Task<CityVM> UpdateCityAsync(CityVM role)
        {
            _logger.LogInformation("Update CityService Initiated");
            var city = await _apiClient.PutAsync("City/id", role);
            _logger.LogInformation("Update CityService Completed");
            return city.Data;
        }
    }
}

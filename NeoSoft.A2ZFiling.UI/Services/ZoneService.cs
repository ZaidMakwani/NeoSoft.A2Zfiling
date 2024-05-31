using Microsoft.EntityFrameworkCore;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class ZoneService : IZoneService
    {
        private readonly IApiClient<ZoneVM> _apiClient;
        private readonly ILogger<ZoneService> _logger;

        public ZoneService(IApiClient<ZoneVM> apiClient, ILogger<ZoneService> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task<ZoneVM> CreateZoneAsync(ZoneVM model)
        {
            _logger.LogInformation("Create ZoneService Initiated");
            var data = await _apiClient.PostAsync("Zone/",model);
            _logger.LogInformation("Create ZoneService Completed");
            return data.Data;
        }

        public async Task<ZoneVM> DeleteZoneAsync(int id)
        {
            _logger.LogInformation("Delete ZoneService Initiated");
            
            var getById = await _apiClient.GetByIdAsync($"Zone/id?id={id}");
            if(getById == null)
            {
                _logger.LogError("Zone not found.");
                return null;
            }
            var zone = getById.Data;
            zone.IsActive = false;
            var updatedata =await _apiClient.PutAsync("Zone/id",zone);
            _logger.LogInformation("Delete ZoneService Completed");

            return updatedata.Data;
        }

        public async Task<ZoneVM> GetByIdAsync(int id)
        {
            _logger.LogInformation("GetById ZoneService Initiated");
            var zones = await _apiClient.GetByIdAsync($"Zone/id?id={id}&api-version=1.0");
            _logger.LogInformation("GetById ZoneService Completed");
            return zones.Data;
            
        }


        public async Task<IEnumerable<ZoneVM>> GetZoneAsync()
        {
            _logger.LogInformation("GetAll ZoneService Initiated");
            var zones = await _apiClient.GetAllAsync("Zone/all");
            _logger.LogInformation("GetAll ZoneService Completed");

            return zones.Data;
        }

       

       
        public async Task<ZoneVM> UpdateZoneAsync(ZoneVM role)
        {
            _logger.LogInformation("UpdateZone ZoneService Initiated");
            var zones = await _apiClient.PutAsync("Zone/id",role);
            _logger.LogInformation("UpdateZone ZoneService Completed");
            return zones.Data;
        }
    }
}

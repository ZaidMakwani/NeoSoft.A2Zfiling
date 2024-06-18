using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class MunicipalService:IMunicipalService
    {
        private readonly IApiClient<MunicipalVM> _client;
        public readonly ILogger<MunicipalService> _logger;
        private readonly IApiClient<MunicipalVM> _dto;
        private readonly IApiClient<int> _id;


        public MunicipalService(IApiClient<MunicipalVM> client, ILogger<MunicipalService> logger, IApiClient<MunicipalVM> dto, IApiClient<int> id)
        {
            _client = client;
            _logger = logger;
            _dto = dto;
            _id = id;
        }
        public async Task<IEnumerable<MunicipalVM>> GetMunicipalAsync()
        {
            _logger.LogInformation("GetAllMunicipal Service initiated");
            var Municipals = await _client.GetAllAsync("v1/Municipal/all");

            _logger.LogInformation("GetAllMunicipal Service conpleted");
            return Municipals.Data;
        }
        public async Task<IEnumerable<MunicipalVM>> GetMunicipalByCityAsync(int id)
        {
            _logger.LogInformation("GetAllMunicipal Service initiated");
            var Municipals = await _client.GetAllAsync($"v1/Municipal/?cityId={id}");
            _logger.LogInformation("GetAllMunicipal Service conpleted");
            return Municipals.Data;
        }
        public async Task<MunicipalVM> CreateMunicipalAsync(MunicipalVM municipal)
        {
            _logger.LogInformation("CreateMunicipal Service initiated");
            var municipals = await _client.PostAsync("v1/Municipal", municipal);
            _logger.LogInformation("Create Municipal Service conpleted");
            return municipals.Data;

        }
        public async Task<MunicipalVM> DeleteMunicipalAsync(int id)
        {
            _logger.LogInformation("Delete MunicipalService Initiated");

            var getById = await _client.GetByIdAsync($"v1/Municipal/{id}");
            if (getById == null)
            {
                _logger.LogError("Municipal Corporation not found.");
                return null;
            }
            var municipal = getById.Data;
            municipal.IsActive = false;
            var updatedata = await _client.PutAsync("v1/Municipal/", municipal);
            _logger.LogInformation("Delete MunicipalService Completed");

            return updatedata.Data;
        }

        public async Task<MunicipalVM> UpdateMunicipalAsync(MunicipalVM municipal)
        {
            _logger.LogInformation("UpdateEvent Service initiated");
            var Events = await _client.PutAsync("v1/Municipal/", municipal);
            _logger.LogInformation("UpdateEvent Service conpleted");
            return Events.Data;
        }

        public async Task<MunicipalVM> GetMunicipalByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetMunicipalById Service initiated");
                var Municipal = await _dto.GetByIdAsync($"v1/Municipal/{id}");
                _logger.LogInformation("GetMunicipalById Service conpleted");
                return Municipal.Data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class SubStatusService:ISubStatusService
    {

        private readonly IApiClient<SubStatusVM> _httpClient;
        private readonly ILogger<SubStatusService> _logger;

        public SubStatusService(IApiClient<SubStatusVM> httpClient, ILogger<SubStatusService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<SubStatusVM> CreateSubStatusAsync(SubStatusVM role)
        {
            try
            {
                _logger.LogInformation("CreateSubStatus Service Initiated");
                var substatus = await _httpClient.PostAsync("SubStatus/", role);
                _logger.LogInformation("CreateSubStatus Service Initiated");
                return substatus.Data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An error occurred while creating the sub status");
                throw ex;
            }
        }

        public async Task<SubStatusVM> DeleteSubStatusAsync(int id)
        {
            try
            {
                _logger.LogInformation("DeleteSubStatus Service Initiated");
                var getById = await _httpClient.GetByIdAsync($"SubStatus/id?id={id}");
                if (getById == null)
                {
                    _logger.LogError("SubStatus not found.");
                    return null;
                }
                var substatus = getById.Data;
                substatus.IsActive = false;
                var updatedata = await _httpClient.PutAsync($"SubStatus/id?id={id}", substatus);
                _logger.LogInformation("DeleteSubStatus Service Completed");
                return updatedata.Data;

            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data ");
                throw ex;
            }
        }

        public async Task<SubStatusVM> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetSubStatusId Service Initiated");
                var substatus = await _httpClient.GetByIdAsync($"SubStatus/id?id={id}");
                _logger.LogInformation("GetSubStatusId Service Completed");
                return substatus.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data ");
                throw ex;
            }
        }

        public async Task<IEnumerable<SubStatusVM>> GetSubStatusAsync()
        {
            try
            {
                _logger.LogInformation("GetSubStatus Service Initiated");
                var substatus = await _httpClient.GetAllAsync("SubStatus/all");
                _logger.LogInformation("GetSubStatus Service Completed");
                return substatus.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while retrieving the data ");
                throw ex;
            }
        }

        public async Task<SubStatusVM> UpdateSubStatusAsync(SubStatusVM role)
        {
            try
            {
                _logger.LogInformation("UpdateSubStatus Service Initiated");
                var substatus = await _httpClient.PutAsync("SubStatus/id", role);
                _logger.LogInformation("UpdateSubStatus Service Initiated");
                return substatus.Data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An error occurred while updating the license");
                throw ex;
            }
        }
    }
}

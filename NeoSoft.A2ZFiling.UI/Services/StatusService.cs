using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class StatusService : IStatusService
    {
        private readonly ILogger<StatusService> _logger;
        private readonly IApiClient<StatusVM> _apiClient;

        public StatusService(ILogger<StatusService> logger, IApiClient<StatusVM> apiClient)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task<StatusVM> CreateStatusAsync(StatusVM role)
        {
            try
            {
                _logger.LogInformation("CreateStatus Service Initiated");
                var status = await _apiClient.PostAsync("Status/", role);
                _logger.LogInformation("CreateStatus Service Initiated");
                return status.Data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An error occurred while creating the permisssion");
                throw ex;
            }
        }

        public async Task<StatusVM> DeleteStatusAsync(int id)
        {
            try
            {
                _logger.LogInformation("DeleteStatus Service Initiated");
                var getById = await _apiClient.GetByIdAsync($"Status/id?id={id}");
                if (getById == null)
                {
                    _logger.LogError("Status not found");
                    return null;
                }
                var status = getById.Data;
                status.IsActive = false;
                var updatedData = await _apiClient.PutAsync($"Status/id?id={id}", status);
                _logger.LogInformation("DeleteStatus Service Completed");
                return updatedData.Data;

            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data ");
                throw ex;
            }
        }

        public async Task<StatusVM> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetStatusById Service Initiated");
                var status = await _apiClient.GetByIdAsync($"Status/id?id={id}");
                _logger.LogInformation("GetStatusById Service Completed");
                return status.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data ");
                throw ex;
            }
        }

        public async Task<IEnumerable<StatusVM>> GetStatusAsync()
        {
            try
            {
                _logger.LogInformation("GetStatus Service Initiated");
                var status = await _apiClient.GetAllAsync("Status/all");
                _logger.LogInformation("GetStatus Service Completed");
                return status.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while retrieving the data ");
                throw ex;
            }
        }

        public async Task<StatusVM> UpdateStatusAsync(StatusVM role)
        {
            try
            {
                _logger.LogInformation("UpdateStatus Service Initiated");
                var status = await _apiClient.PutAsync("Status/id", role);
                _logger.LogInformation("UpdateStatus Service Initiated");
                return status.Data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An error occurred while updating the status");
                throw ex;
            }
        }
    }
}

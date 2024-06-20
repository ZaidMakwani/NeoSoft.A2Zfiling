using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class StateService : IStateService
    {
        private readonly IApiClient<StateVM> _apiClient;
        private readonly ILogger<StateService> _logger;

        public StateService(IApiClient<StateVM> apiClient, ILogger<StateService> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task<StateVM> CreateStateAsync(StateVM model)
        {
            _logger.LogInformation("Create CitService Initiated");
            var data = await _apiClient.PostAsync("State/", model);
            _logger.LogInformation("Create StateService Completed");
            return data.Data;
        }

        public async Task<StateVM> DeleteStateAsync(int id)
        {
            _logger.LogInformation("Delete StateService Initiated");

            var getById = await _apiClient.GetByIdAsync($"State/id?id={id}");
            if (getById == null)
            {
                _logger.LogError("State not found.");
                return null;
            }
            var State = getById.Data;
            State.IsActive = false;
            var updatedata = await _apiClient.PutAsync("State/id", State);
            _logger.LogInformation("Delete StateService Completed");

            return updatedata.Data;
        }

        public async Task<StateVM> GetByIdAsync(int id)
        {
            _logger.LogInformation("GetById StateService Initiated");
            var State = await _apiClient.GetByIdAsync($"State/id?id={id}");
            _logger.LogInformation("GetById StateService Completed");
            return State.Data;
        }

        public async Task<IEnumerable<StateVM>> GetStateAsync()
        {
            _logger.LogInformation("GetAll StateService Initiated");
            var zones = await _apiClient.GetAllAsync("State/GetAllStates/all");
            _logger.LogInformation("GetAll StateService Completed");

            return zones.Data;
        }

        public async Task<StateVM> UpdateStateAsync(StateVM role)
        {
            _logger.LogInformation("Update StateService Initiated");
            var State = await _apiClient.PutAsync("State/id", role);
            _logger.LogInformation("Update StateService Completed");
            return State.Data;
        }
    }
}

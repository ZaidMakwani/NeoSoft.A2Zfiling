using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class FormService : IFormService
    {
        private readonly IApiClient<ContactUSVM> _apiClient;
        private readonly ILogger<FormService> _logger;

        public FormService(IApiClient<ContactUSVM> apiClient, ILogger<FormService> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public async Task<ContactUSVM> CreateFormAsync(ContactUSVM model)
        {
            _logger.LogInformation("Create CitService Initiated");
            var data = await _apiClient.PostAsync("v1/Account/CreateForm", model);
            _logger.LogInformation("Create CityService Completed");
            return data.Data;
        }

        //public Task<ContactUSVM> CreateFormAsync(ContactUSVM role)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ContactUSVM> DeleteFormAsync(int id)
        {
            _logger.LogInformation("Delete FormService Initiated");

            var getById = await _apiClient.GetByIdAsync($"Form/id?id={id}");
            if (getById == null)
            {
                _logger.LogError("Form not found.");
                return null;
            }
            var Form = getById.Data;
            var updatedata = await _apiClient.PutAsync("Form/id", Form);
            _logger.LogInformation("Delete FormService Completed");

            return updatedata.Data;
        }

        public async Task<ContactUSVM> GetByIdAsync(int id)
        {
            _logger.LogInformation("GetById FormService Initiated");
            var Form = await _apiClient.GetByIdAsync($"v1/Account/GetContactById={id}");
            _logger.LogInformation("GetById FormService Completed");
            return Form.Data;
        }

        public async Task<IEnumerable<ContactUSVM>> GetFormAsync()
        {
            _logger.LogInformation("GetAll FormService Initiated");
            var zones = await _apiClient.GetAllAsync("v1/Account/GetAllContactMessage/all");
            _logger.LogInformation("GetAll FormService Completed");

            return zones.Data;
        }

        public async Task<ContactUSVM> UpdateFormAsync(ContactUSVM role)
        {
            _logger.LogInformation("Update FormService Initiated");
            var Form = await _apiClient.PutAsync("v1/Account/Update", role);
            _logger.LogInformation("Update FormService Completed");
            return Form.Data;
        }
    }
}

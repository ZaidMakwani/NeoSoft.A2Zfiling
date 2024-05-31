using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class UserPermissionService : IUserPermission
    {
        private readonly ILogger<UserPermissionService> _logger;
        private readonly IApiClient<UserPermissionVM> _apiClient;

        public UserPermissionService(ILogger<UserPermissionService> logger, IApiClient<UserPermissionVM> apiClient)
        {
            _apiClient = apiClient;
            _logger = logger;
        }
        public async Task<IEnumerable<UserPermissionVM>> GetUserPermissionAsync()
        {
            try
            {
                _logger.LogInformation("GetUserPermission Service Initiated");
                var permission = await _apiClient.GetAllAsync("UserPermission/all");
                _logger.LogInformation("GetUserPermission Service Completed");
                return permission.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while retrieving the data ");
                throw ex;
            }
        }
    }
}

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

        public async Task<UserPermissionVM> CreateUserPermissionAsync(UserPermissionVM role)
        {
                try
                {
                    _logger.LogInformation("Create UserPermission Service Initiated");
                    var permission = await _apiClient.PostAsync("UserPermission/", role);
                    _logger.LogInformation("Create UserPermission Service Initiated");
                    return permission.Data;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("An error occurred while creating the user permisssion");
                    throw ex;
                }
            }

        public async Task<UserPermissionVM> DeleteUserPermissionAsync(int id)
        {
            try
            {
                _logger.LogInformation("DeleteUserPermission Service Initiated");
                var getById = await _apiClient.GetByIdAsync($"UserPermission/id?id={id}");
                if (getById == null)
                {
                    _logger.LogError("UserPermission not found");
                    return null;
                }
                var permission = getById.Data;
                permission.IsActive = false;
                var updatedData = await _apiClient.PutAsync($"UserPermission/id", permission);
                _logger.LogInformation("DeleteUserPermission Service Completed");
                return updatedData.Data;

            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data ");
                throw ex;
            }
        }

        public async Task<UserPermissionVM> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetUserPermissionById Service Initiated");
                var permission = await _apiClient.GetByIdAsync($"UserPermission/id?id={id}");
                _logger.LogInformation("GetUserPermissionById Service Completed");
                return permission.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data ");
                throw ex;
            }
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

        public async Task<UserPermissionVM> UpdateUserPermissionAsync(UserPermissionVM role)
        {
            try
            {
                _logger.LogInformation("UpdateUserPermission Service Initiated");
                var permission = await _apiClient.PutAsync("UserPermission/id", role);
                _logger.LogInformation("UpdateUserPermission Service Initiated");
                return permission.Data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An error occurred while updating the user permisssion");
                throw ex;
            }
        }
    }
}

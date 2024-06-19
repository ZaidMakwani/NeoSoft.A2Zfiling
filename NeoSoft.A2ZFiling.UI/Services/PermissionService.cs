using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using System.Security.Claims;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly ILogger<PermissionService> _logger;
        private readonly IApiClient<PermissionVM> _apiClient;

        public PermissionService(ILogger<PermissionService> logger, IApiClient<PermissionVM> apiClient)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        //[HttpPost("UserId")]
        [HttpPost]
        public async Task<PermissionVM> CreatePermissionAsync(PermissionVM role/*, string token*/)
        {
            try
            {
                _logger.LogInformation("CreatePermission Service Initiated");
                //var permission = await _apiClient.PostAsync("Permission/token?token={token}", role);
                var permission = await _apiClient.PostAsync("Permission/", role);

                _logger.LogInformation("CreatePermission Service Initiated");
                return permission.Data;
            }
            catch(Exception ex)
            {
                _logger.LogInformation("An error occurred while creating the permisssion");
                throw ex;
            }
        }

        public async Task<PermissionVM> DeletePermissionAsync(int id)
        {

            try
            {
                _logger.LogInformation("DeletePermission Service Initiated");
                var getById = await _apiClient.GetByIdAsync($"Permission/id?id={id}");
                if( getById == null ) {
                    _logger.LogError("Permission not found");
                    return null;
                }
                var permission = getById.Data;
                permission.IsActive = false;
                var updatedData = await _apiClient.PutAsync($"Permission/id",permission);
                _logger.LogInformation("DeletePermission Service Completed");
                return updatedData.Data;
                
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data ");
                throw ex;
            }
        }

        public async Task<PermissionVM> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetPermissionById Service Initiated");
                var permission = await _apiClient.GetByIdAsync($"Permission/id?id={id}");
                _logger.LogInformation("GetPermissionById Service Completed");
                return permission.Data;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data ");
                throw ex;
            }
        }

        public async Task<IEnumerable<PermissionVM>> GetPermissionAsync()
        {
            try
            {
                _logger.LogInformation("GetPermission Service Initiated");
                var permission = await _apiClient.GetAllAsync("Permission/all");
                _logger.LogInformation("GetPermission Service Completed");
                return permission.Data;
            }
            catch(Exception ex)
            {
                _logger.LogError("An error occurred while retrieving the data ");
                throw ex;
            }
        }

     

        public async Task<PermissionVM> UpdatePermissionAsync(PermissionVM role)
        {
            try
            {
                _logger.LogInformation("UpdatePermission Service Initiated");
                var permission = await _apiClient.PutAsync("Permission/id", role);
                _logger.LogInformation("UpdatePermission Service Initiated");
                return permission.Data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An error occurred while updating the permisssion");
                throw ex;
            }
        }
    }
}

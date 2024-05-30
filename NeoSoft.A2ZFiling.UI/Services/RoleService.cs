using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRoleaDetails;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;
using System.Security.Cryptography;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class RoleService : IRoleService
    {
        private readonly IApiClient<RoleVM> _client;
        public readonly ILogger<RoleService> _logger;
        private readonly IApiClient<GetRoleDto> _dto;
        private readonly IApiClient<int> _id;


        public RoleService(IApiClient<RoleVM> client, ILogger<RoleService> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<IEnumerable<RoleVM>> GetRolesAsync()
        {
            _logger.LogInformation("GetAllRole Service initiated");
            var Roles = await _client.GetAllAsync("v1/Roles/GetAllRoles/all");
            
            _logger.LogInformation("GetAllRole Service completed");
            return Roles.Data;
        }
        public async Task<IEnumerable<RoleVM>> GetAllRolesAsync()
        {
            _logger.LogInformation("GetAllRole Service initiated");
            var Roles = await _client.GetAllAsync("v1/Roles/GetAllRoles/all");

            _logger.LogInformation("GetAllRole Service completed");
            return Roles.Data;
        }

        public async Task<RoleVM> CreateRoleAsync(RoleVM role)
        {
            _logger.LogInformation("CreateRole Service initiated");
            var roles = await _client.PostAsync("v1/Roles/Create", role);
            _logger.LogInformation("CreateRoleAsync Service conpleted");
            return roles.Data;

        }
       
        public async Task<RoleVM> DeleteRoleAsync(int id)
        {
            _logger.LogInformation("Delete RoleService Initiated");

            var getById = await _client.GetByIdAsync($"v1/Roles/GetRoleById?id={id}");
            if (getById == null)
            {
                _logger.LogError("Roles not found.");
                return null;
            }
            var role = getById.Data;
            role.IsActive = false;
            var updatedata = await _client.PutAsync("v1/Roles/Update", role);
            _logger.LogInformation("Delete RoleService Completed");

            return updatedata.Data;
        }

        public async Task<RoleVM> UpdateRoleAsync(RoleVM role)
        {
            _logger.LogInformation("UpdateRole Service initiated");
            //var getById = await _client.GetByIdAsync($"v1/Roles/GetRoleById?id={role.RoleId}");
            //if (getById.Data.IsActive == false)
            //{
            //    _logger.LogError("Role is InActive not found.");
            //    return EmptyResult();
            //}
            
                var Events = await _client.PutAsync("v1/Roles/Update", role);
                _logger.LogInformation("UpdateRole Service conpleted");
                return Events.Data;
            
        }

        public async Task<RoleVM> GetRoleByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetRoleById Service initiated");
                var Role = await _client.GetByIdAsync($"v1/Roles/GetRoleById?id={id}");
                _logger.LogInformation("GetRoleById Service conpleted");
                return Role.Data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

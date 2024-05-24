using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRoleaDetails;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class RoleService : IRoleService
    {
        private readonly IApiClient<RoleVM> _client;
        public readonly ILogger<RoleService> _logger;
        private readonly IApiClient<GetRoleDto> _dto;
        

        public RoleService(IApiClient<RoleVM> client, ILogger<RoleService> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<IEnumerable<RoleVM>> GetRolesAsync()
        {
            _logger.LogInformation("GetAllRole Service initiated");
            var Roles = await _client.GetAllAsync("v1/Roles/GetAllRoles/all");
            
            _logger.LogInformation("GetAllRole Service conpleted");
            return Roles.Data;
        }
        public async Task<RoleVM> CreateRoleAsync(RoleVM role)
        {
            _logger.LogInformation("CreateRole Service initiated");
            var roles = await _client.PostAsync("v1/Roles/Create", role);
            _logger.LogInformation("CreateRoleAsync Service conpleted");
            return roles.Data;

        }
       public async Task<string> DeleteRoleAsync(int id) 
        {
            var roles=await _client.DeleteAsync(""+id);
            return roles;
        }

        public Task<RoleVM> UpdateRoleAsync(RoleVM role)
        {
            throw new NotImplementedException();
        }

        //public Task<RoleVM> GetRoleByIdAsync(int id)
        //{

            
        //}
    }
}

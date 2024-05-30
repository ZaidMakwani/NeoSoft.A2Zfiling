﻿using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleVM>> GetRolesAsync();
        Task<RoleVM> CreateRoleAsync(RoleVM role);
        Task<RoleVM> GetRoleByIdAsync(int id);
        Task<RoleVM> UpdateRoleAsync(RoleVM role);
        Task<RoleVM> DeleteRoleAsync(int id);
        Task<IEnumerable<RoleVM>> GetAllRolesAsync();
    }
}
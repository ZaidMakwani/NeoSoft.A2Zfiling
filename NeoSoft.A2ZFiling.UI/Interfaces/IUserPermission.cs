﻿using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IUserPermission
    {
        Task<IEnumerable<UserPermissionVM>> GetUserPermissionAsync();
    }
}

using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Contracts.Persistence
{
    public interface IRoleRepository
    {
        public Task<Role> GetRoleIdAsync(string userId);
    }

}

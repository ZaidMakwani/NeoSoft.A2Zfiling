using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Persistence.Repositories
{
   
    public class RoleRepository : BaseRepository<Token>, IRoleRepository
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext dbContext, ILogger<Token> logger) : base(dbContext, logger)
        {
            _logger = logger;
            _context = dbContext;
        }

        public Task<Role> GetRoleIdAsync(string roleName)
        {
           return _context.Role.FirstOrDefaultAsync(r => r.RoleName == roleName);
        }
    }
}

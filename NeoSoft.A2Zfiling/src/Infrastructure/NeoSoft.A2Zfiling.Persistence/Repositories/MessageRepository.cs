﻿using NeoSoft.A2Zfiling.Application.Contracts.Infrastructure;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly string cacheKey = $"{typeof(Message)}";
        private readonly ILogger _logger;
        private readonly ICacheService _cacheService;
        public MessageRepository(ApplicationDbContext dbContext, ILogger<Message> logger, ICacheService cacheService) : base(dbContext, logger)
        {
            _logger = logger;
            _cacheService = cacheService;
        }

        public async Task<Message> GetMessage(string Code, string Lang)
        {
            _logger.LogInformation("GetAllNotifications Initiated");
            if (!_cacheService.TryGet(cacheKey, out IReadOnlyList<Message> cachedList))
            {
                cachedList = await _dbContext.Set<Message>().ToListAsync();
                _cacheService.Set(cacheKey, cachedList);
            }
            _logger.LogInformation("GetAllNotifications Completed");
            return cachedList.FirstOrDefault(x => x.Code == Code && x.Language == Lang);
        }
    }
}

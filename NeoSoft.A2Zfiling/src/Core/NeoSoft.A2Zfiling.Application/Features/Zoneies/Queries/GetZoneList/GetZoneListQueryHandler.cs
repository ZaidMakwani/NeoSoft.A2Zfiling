using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneList
{
    public class GetZoneListQueryHandler : IRequestHandler<GetListQuery, Response<IEnumerable<GetZoneListDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetZoneListQueryHandler> _logger;
        private readonly IAsyncRepository<Zones> _asyncRepository;

        public GetZoneListQueryHandler(IMapper mapper,ILogger<GetZoneListQueryHandler> logger,IAsyncRepository<Zones> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper=mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetZoneListDto>>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allZones = (await _asyncRepository.ListAllAsync())/*.Where(x => x.IsActive == true);*/;
            
            var zones = _mapper.Map<IEnumerable<GetZoneListDto>>(allZones);
            
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetZoneListDto>>(zones, "Data Fetched Successfully");
        }

       
    }
}

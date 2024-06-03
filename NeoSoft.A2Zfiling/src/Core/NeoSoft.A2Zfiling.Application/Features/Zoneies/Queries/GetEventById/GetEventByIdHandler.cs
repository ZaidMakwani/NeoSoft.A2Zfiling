﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.UpdateZone;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneListWithEvent
{
    public class GetEventByIdHandler : IRequestHandler<GetZoneByIdCommand, Response<GetEventByIdDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Zones> _asyncRepository;
        private readonly ILogger<GetEventByIdHandler> _logger;

        public GetEventByIdHandler(IMapper mapper, IAsyncRepository<Zones> asyncRepository, ILogger<GetEventByIdHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<GetEventByIdDto>> Handle(GetZoneByIdCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initiated");
            var getById = (await _asyncRepository.GetByIdAsync(request.ZoneId));
            if (getById == null)
            {
                return new Response<GetEventByIdDto>("Zone not found.");
            }
            if (getById.IsActive != true)
            {
                return new Response<GetEventByIdDto>("This Zone is not Active");
            }
            var data = _mapper.Map<GetEventByIdDto>(getById);
            _logger.LogInformation("Handler Completed");
            return new Response<GetEventByIdDto>(data, "Data Found Successfully.");
        }
    }
}
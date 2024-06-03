﻿using AutoMapper;
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

namespace NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.UpdateZone
{
    public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand, Response<UpdateZoneDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateZoneCommandHandler> _logger;
        private readonly IAsyncRepository<Zones> _asyncRepository;

        public UpdateZoneCommandHandler(IMapper mapper, ILogger<UpdateZoneCommandHandler> logger, IAsyncRepository<Zones> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<UpdateZoneDto>> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initiated");
            var zoneToUpdate = await _asyncRepository.GetByIdAsync(request.ZoneId);
            if (zoneToUpdate == null)
            {
                return new Response<UpdateZoneDto>("Zone not found.");
            }
            _mapper.Map(request, zoneToUpdate);
            await _asyncRepository.UpdateAsync(zoneToUpdate);
            var updateZone = _mapper.Map<UpdateZoneDto>(zoneToUpdate);
            _logger.LogInformation("Handler Completed");
            return new Response<UpdateZoneDto>(updateZone, "Zone Updated Successfully");

        }
    }
}
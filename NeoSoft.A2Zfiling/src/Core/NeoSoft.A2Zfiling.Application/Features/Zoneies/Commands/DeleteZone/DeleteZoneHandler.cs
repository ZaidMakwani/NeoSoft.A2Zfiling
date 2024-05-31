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

namespace NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.DeleteZone
{
    public class DeleteZoneCommandHandler : IRequestHandler<DeleteZoneCommand, Response<DeleteZoneDto>>
    {
        private readonly ILogger<DeleteZoneCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Zones> _asyncRepository;

        public DeleteZoneCommandHandler(ILogger<DeleteZoneCommandHandler> logger, IMapper mapper, IAsyncRepository<Zones> asyncRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }
        public async Task<Response<DeleteZoneDto>> Handle(DeleteZoneCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initiated");

            var zone = await _asyncRepository.GetByIdAsync(request.ZoneId);

            if (zone == null)
            {
                return new Response<DeleteZoneDto>("Zone not found");
            }
            zone.IsActive = false;
            zone.LastModifiedDate = DateTime.Now;
            //zone.LastModifiedBy = "";
            await _asyncRepository.UpdateAsync(zone);
            //await _asyncRepository.DeleteAsync(zone);

            var deleteZoneDto = _mapper.Map<DeleteZoneDto>(zone);
            _logger.LogInformation("Handler Completed");

            return new Response<DeleteZoneDto>(deleteZoneDto, "Zone Deleted Successfully");
        }

    }
}
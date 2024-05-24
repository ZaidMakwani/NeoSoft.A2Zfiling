﻿using AutoMapper;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NeoSoft.A2Zfiling.Application.Exceptions;

namespace NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.CreateZone
{
    public class CreateZoneCommandHandler : IRequestHandler<CreateZoneCommand, Response<CreateZoneDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Zones> _asyncRepository;

        
        public CreateZoneCommandHandler(IMapper mapper, IAsyncRepository<Zones> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }


        public async Task<Response<CreateZoneDto>> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
        {

            Response<CreateZoneDto> createZoneCommandResponse = null;


            var zone = new Zones()
            {
                ZoneName = request.ZoneName,
                IsActive = true,
                CreatedBy = "SuperAdmin",
                CreatedDate = DateTime.Now
            };
            zone = await _asyncRepository.AddAsync(zone);
            createZoneCommandResponse = new Response<CreateZoneDto>(_mapper.Map<CreateZoneDto>(zone), "Zone Created Successfully");


            return createZoneCommandResponse;

        }
    }
}
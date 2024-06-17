﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateById;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Response<CreateCityDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCityCommandHandler> _logger;
        private readonly IAsyncRepository<City> _asyncRepository;

        public CreateCityCommandHandler(IMapper mapper, ILogger<CreateCityCommandHandler> logger, IAsyncRepository<City> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<CreateCityDto>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");

                var city = new City()
                {
                    CityName = request.CityName,
                    IsActive = true,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now,
                    StateId = request.StateId,
                    ZoneId = request.ZoneId,

                 




                };
                var data = await _asyncRepository.AddAsync(city);

                var result = _mapper.Map<CreateCityDto>(data);


                _logger.LogInformation("Handler Completed");
                return new Response<CreateCityDto>(result, "City Inserted Successfully"); ;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

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

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList
{
    public class GetCityListHanlder : IRequestHandler<GetCityListCommand, Response<IEnumerable<GetCityListDto>>>
    {
        private readonly IAsyncRepository<City> _asyncRepository;
        private readonly ILogger<GetCityListHanlder> _logger;
        private readonly IMapper _mapper;

        public GetCityListHanlder(IAsyncRepository<City> asyncRepository, ILogger<GetCityListHanlder> logger, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetCityListDto>>> Handle(GetCityListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var allcities = (await _asyncRepository.ListAllAsync()).Where(x => x.IsActive == true);

                var cities = _mapper.Map<IEnumerable<GetCityListDto>>(allcities);
                _logger.LogInformation("Handler Completed");
                return new Response<IEnumerable<GetCityListDto>>(cities, "Data Fetched Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
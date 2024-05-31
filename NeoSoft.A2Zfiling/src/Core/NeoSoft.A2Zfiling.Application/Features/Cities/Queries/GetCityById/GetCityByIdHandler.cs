using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneListWithEvent;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityById
{
    public class GetCityByIdHandler : IRequestHandler<GetCityByIdCommand, Response<GetCityByIdDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<City> _asyncRepository;
        private readonly ILogger<GetCityByIdHandler> _logger;


        public GetCityByIdHandler(IMapper mapper, IAsyncRepository<City> asyncRepository, ILogger<GetCityByIdHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<GetCityByIdDto>> Handle(GetCityByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var getById = (await _asyncRepository.GetByIdAsync(request.CityId));
                if (getById == null)
                {
                    return new Response<GetCityByIdDto>("City not found.");
                }
                if (getById.IsActive != true)
                {
                    return new Response<GetCityByIdDto>("This City is not Active");
                }
                var data = _mapper.Map<GetCityByIdDto>(getById);
                _logger.LogInformation("Handler Completed");
                return new Response<GetCityByIdDto>(data, "Data Found Successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

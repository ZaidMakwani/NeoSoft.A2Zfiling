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

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Command.UpdateCity
{
    public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, Response<UpdateCityDto>>
    {
        private readonly IMapper _mapper;
        private ILogger<UpdateCityHandler> _logger;
        private IAsyncRepository<City> _asyncRepository;

        public UpdateCityHandler(IMapper mapper, ILogger<UpdateCityHandler> logger, IAsyncRepository<City> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<UpdateCityDto>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var getById =await _asyncRepository.GetByIdAsync(request.CityId);
                if (getById == null)
                {
                    return new Response<UpdateCityDto>("City not found.");
                }
                _mapper.Map(request, getById);
                await _asyncRepository.UpdateAsync(getById);
                var data = _mapper.Map<UpdateCityDto>(getById);
                _logger.LogInformation("Handler Completed");
                return new Response<UpdateCityDto>(data, "City Updated Successfully");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

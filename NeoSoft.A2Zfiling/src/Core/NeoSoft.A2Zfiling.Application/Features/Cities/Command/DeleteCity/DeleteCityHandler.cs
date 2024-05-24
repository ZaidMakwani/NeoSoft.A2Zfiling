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

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Command.DeleteCity
{
    public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, Response<DeleteCityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<City> _asyncRepository;
        private readonly ILogger<DeleteCityHandler> _logger;

        public DeleteCityHandler(IMapper mapper, IAsyncRepository<City> asyncRepository, ILogger<DeleteCityHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
           _logger = logger;
        }

        public async Task<Response<DeleteCityDto>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var getById = await _asyncRepository.GetByIdAsync(request.CityId);
                if(getById == null)
                {
                    _logger.LogInformation("City not found");
                    return new Response<DeleteCityDto>("City not found.");
                }
                getById.IsActive = false;
                //getById.LastModifiedBy = "";
                getById.LastModifiedDate= DateTime.Now;

                await _asyncRepository.UpdateAsync(getById);

                var deleteCitiesDto = _mapper.Map<DeleteCityDto>(getById);
                _logger.LogInformation("Handler Completed");
                return new Response<DeleteCityDto>(deleteCitiesDto, "City Deleted Successfully");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityById;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeById
{
    public class GetLicenseTypeByIdHandler : IRequestHandler<GetLicenseTypeByIdCommand, Response<GetLicenseTypeByIdDto>>
    {
        private readonly ILogger<GetLicenseTypeByIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<LicenseType> _asyncRepository;

        public GetLicenseTypeByIdHandler(ILogger<GetLicenseTypeByIdHandler> logger, IMapper mapper, IAsyncRepository<LicenseType> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<GetLicenseTypeByIdDto>> Handle(GetLicenseTypeByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var getById = (await _asyncRepository.GetByIdAsync(request.LicenseTypeId));
                if (getById == null)
                {
                    return new Response<GetLicenseTypeByIdDto>("License Type not found.");
                }
                if (getById.IsActive != true)
                {
                    return new Response<GetLicenseTypeByIdDto>("This License Type is not Active");
                }
                var data = _mapper.Map<GetLicenseTypeByIdDto>(getById);
                _logger.LogInformation("Handler Completed");
                return new Response<GetLicenseTypeByIdDto>(data, "Data Found Successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

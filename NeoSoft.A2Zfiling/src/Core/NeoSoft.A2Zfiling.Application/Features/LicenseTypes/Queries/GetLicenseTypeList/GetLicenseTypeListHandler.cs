using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeList
{
    public class GetLicenseTypeListHandler : IRequestHandler<GetLicenseTypeListCommand, Response<IEnumerable<GetLicenseTypeListDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetLicenseTypeListHandler> _logger;
        private readonly IAsyncRepository<LicenseType> _asyncRepository;

        public GetLicenseTypeListHandler(IMapper mapper, ILogger<GetLicenseTypeListHandler> logger, IAsyncRepository<LicenseType> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetLicenseTypeListDto>>> Handle(GetLicenseTypeListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var allicense = (await _asyncRepository.ListAllAsync()).Where(x => x.IsActive == true);

                var license = _mapper.Map<IEnumerable<GetLicenseTypeListDto>>(allicense);
                _logger.LogInformation("Handler Completed");
                return new Response<IEnumerable<GetLicenseTypeListDto>>(license, "Data Fetched Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

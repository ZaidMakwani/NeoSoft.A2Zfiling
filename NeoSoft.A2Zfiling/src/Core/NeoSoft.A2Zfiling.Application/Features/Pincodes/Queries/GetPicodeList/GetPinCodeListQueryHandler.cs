using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
//using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPicodeList
{
    public class GetPinCodeListQueryHandler : IRequestHandler<GetPinCodeListQuery, Response<IEnumerable<PinCodeListVm>>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAsyncRepository<PinCode> _pincodeRepsitory;
        public GetPinCodeListQueryHandler(IMapper mapper,ILogger<GetPinCodeListQueryHandler> logger, IAsyncRepository<PinCode> stateRepsitory)
        {
            _mapper = mapper;
            _logger = logger;
            _pincodeRepsitory = stateRepsitory;
        }

        public async Task<Response<IEnumerable<PinCodeListVm>>> Handle(GetPinCodeListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allPinCode = (await _pincodeRepsitory.ListAllAsync()).OrderBy(x => x.PinCodeNumber).Where(x=> x.IsActive == true);
            var pincode = _mapper.Map<IEnumerable<PinCodeListVm>>(allPinCode);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<PinCodeListVm>>(pincode, "success");
        }

    }

}

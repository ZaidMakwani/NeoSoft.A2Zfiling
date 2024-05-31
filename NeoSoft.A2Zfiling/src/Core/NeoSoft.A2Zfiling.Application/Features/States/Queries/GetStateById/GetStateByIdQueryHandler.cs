using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPicodeList;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPinCode;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateById
{
    public class GetStateByIdQueryHandler : IRequestHandler<GetStateByIdQuery, Response<StateVM>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAsyncRepository<State> _stateRepsitory;
        public GetStateByIdQueryHandler(IMapper mapper, ILogger<GetStateListQueryHandler> logger, IAsyncRepository<State> stateRepsitory)
        {
            _mapper = mapper;
            _logger = logger;
            _stateRepsitory = stateRepsitory;
        }

        public async Task<Response<StateVM>> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var company = await _stateRepsitory.GetByIdAsync(request.StateId);
            var companyVM = _mapper.Map<StateVM>(company);
            _logger.LogInformation("Hanlde Completed");

            return new Response<StateVM>(companyVM, "success");
        }

    }
}

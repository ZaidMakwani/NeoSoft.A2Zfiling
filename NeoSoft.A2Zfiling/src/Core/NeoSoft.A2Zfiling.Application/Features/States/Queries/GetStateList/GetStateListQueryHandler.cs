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

namespace NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateList
{
    public class GetStateListQueryHandler : IRequestHandler<GetStateListQuery, Response<IEnumerable<StateListVm>>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAsyncRepository<State> _stateRepsitory;
        public GetStateListQueryHandler(IMapper mapper, ILogger<GetStateListQueryHandler> logger, IAsyncRepository<State> asyncRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _stateRepsitory = asyncRepository;
        }

        public async Task<Response<IEnumerable<StateListVm>>> Handle(GetStateListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allState = (await _stateRepsitory.ListAllAsync()).OrderBy(x => x.StateName).Where(x => x.IsActive == true);
            var states = _mapper.Map<IEnumerable<StateListVm>>(allState);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<StateListVm>>(states, "success");
        }

    }
}

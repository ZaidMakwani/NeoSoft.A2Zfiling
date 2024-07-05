using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseList;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Query.GetAllMessagees
{
    public class GetAllMessagesListHandler : IRequestHandler<GetAllMessagesListCommand, Response<IEnumerable<GetAllMessagesListDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllMessagesListHandler> _logger;
        private readonly IAsyncRepository<ContactUS> _contactRepsitory;
        public GetAllMessagesListHandler(IMapper mapper, ILogger<GetAllMessagesListHandler> logger, IAsyncRepository<ContactUS> contactRepsitory)
        {
            _mapper = mapper;
            _logger = logger;
            _contactRepsitory = contactRepsitory;
        }


        public async Task<Response<IEnumerable<GetAllMessagesListDTO>>> Handle(GetAllMessagesListCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allState = (await _contactRepsitory.ListAllAsync());
            var states = _mapper.Map<IEnumerable<GetAllMessagesListDTO>>(allState);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetAllMessagesListDTO>>(states, "success");
        }
    }

    }



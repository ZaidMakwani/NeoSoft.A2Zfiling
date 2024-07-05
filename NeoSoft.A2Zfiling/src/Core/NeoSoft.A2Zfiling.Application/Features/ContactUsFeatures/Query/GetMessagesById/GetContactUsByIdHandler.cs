using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateById;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Query.GetMessagesById
{
    public class GetContactUsByIdHandler : IRequestHandler<GetContactUsByIdQuery, Response<GetContactUsByIdDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetContactUsByIdHandler> _logger;
        private readonly IAsyncRepository<ContactUS> _contactRepsitory;
        public GetContactUsByIdHandler(IMapper mapper, ILogger<GetContactUsByIdHandler> logger, IAsyncRepository<ContactUS> contactRepsitory)
        {
            _mapper = mapper;
            _logger = logger;
            _contactRepsitory = contactRepsitory;
        }

        public async Task<Response<GetContactUsByIdDto>> Handle(GetContactUsByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var contact = await _contactRepsitory.GetByIdAsync(request.Id);
            var contactVV = _mapper.Map<GetContactUsByIdDto>(contact);
            _logger.LogInformation("Hanlde Completed");

            return new Response<GetContactUsByIdDto>(contactVV, "success");
        }

       
    }
}


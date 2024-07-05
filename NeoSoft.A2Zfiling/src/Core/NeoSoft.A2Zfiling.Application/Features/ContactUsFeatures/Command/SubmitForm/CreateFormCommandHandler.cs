using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.CreateState;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Command.SubmitForm
{
    public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, Response<CreateFormDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreateFormCommandHandler> _logger;
        private readonly IAsyncRepository<ContactUS> _contactRepository;

        public CreateFormCommandHandler(IMapper mapper, ILogger<CreateFormCommandHandler> logger, IAsyncRepository<ContactUS> contactRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<CreateFormDTO>> Handle(CreateFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");

                var form = new ContactUS()
                {
                    YourName = request.YourName,
                    YourEmail = request.YourEmail,
                    Message = request.Message,

                };
                var data = await _contactRepository.AddAsync(form);

                var result = _mapper.Map<CreateFormDTO>(data);


                _logger.LogInformation("Handler Completed");
                return new Response<CreateFormDTO>(result, "Form Inserted Successfully"); ;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

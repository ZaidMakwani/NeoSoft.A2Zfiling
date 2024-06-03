using AutoMapper;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NeoSoft.A2Zfiling.Application.Exceptions;
using System.Reflection.Metadata;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreatePinCodeCommand;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateState;



public class CreatePinCodeCommandHandler : IRequestHandler<CreatePinCodeCommand, Response<CreatePinCodeDto>>
    {
        private readonly IMapper _mapper;
        
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<PinCode> _pinCodeRepsitory;

        public CreatePinCodeCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<PinCode> pinCodeRepsitory)
        {
            _mapper = mapper;            
            _messageRepository = messageRepository;
        _pinCodeRepsitory = pinCodeRepsitory;
        }

        public async Task<Response<CreatePinCodeDto>> Handle(CreatePinCodeCommand request, CancellationToken cancellationToken)
        {
            Response<CreatePinCodeDto> createPinCodeCommandResponse = null;

           
                var pincode = new PinCode() { PinCodeNumber = request.PinCodeNumber, IsActive=request.IsActive };
            pincode = await _pinCodeRepsitory.AddAsync(pincode);
            createPinCodeCommandResponse = new Response<CreatePinCodeDto>(_mapper.Map<CreatePinCodeDto>(pincode), "success");
            

            return createPinCodeCommandResponse;
        }
    }


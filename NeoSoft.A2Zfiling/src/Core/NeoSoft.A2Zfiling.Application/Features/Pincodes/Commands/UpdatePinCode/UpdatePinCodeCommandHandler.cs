using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
//using NeoSoft.A2Zfiling.Application.StateFeatures.UpdateState;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Pincodes.Commands.UpdatePinCode
{
    public class UpdatePinCodeCommandHandler : IRequestHandler<UpdatePinCodeCommand, Response<UpdatePinCodeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<PinCode> _pincodeRepsitory;

        public UpdatePinCodeCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository, IAsyncRepository<PinCode> pinRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
            _pincodeRepsitory = pinRepsitory;
        }

        public async Task<Response<UpdatePinCodeDto>> Handle(UpdatePinCodeCommand request, CancellationToken cancellationToken)
        {
            var pinCodeToUpdate = await _pincodeRepsitory.GetByIdAsync(request.PinCodeId);
            if (pinCodeToUpdate == null)
            {
                return new Response<UpdatePinCodeDto>("PinCode not found.");
            }
            _mapper.Map(request, pinCodeToUpdate);
            await _pincodeRepsitory.UpdateAsync(pinCodeToUpdate);
            var updatePinCode = _mapper.Map<UpdatePinCodeDto>(pinCodeToUpdate);
            return new Response<UpdatePinCodeDto>(updatePinCode, "PinCode Updated Successfully");

        }
    }


}

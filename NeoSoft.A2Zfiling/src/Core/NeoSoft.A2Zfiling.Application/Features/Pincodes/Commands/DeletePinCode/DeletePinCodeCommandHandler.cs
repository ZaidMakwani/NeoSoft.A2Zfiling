using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
//using NeoSoft.A2Zfiling.Application.StateFeatures.DeleteState;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Pincodes.Commands.DeletePinCode
{
    public class DeletePinCodeCommandHandler : IRequestHandler<DeletePinCodeCommand, Response<DeletePinCodeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<PinCode> _picodeRepsitory;

        public DeletePinCodeCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository, IAsyncRepository<PinCode> stateRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
            _picodeRepsitory = stateRepsitory;
        }

        public async Task<Response<DeletePinCodeDto>> Handle(DeletePinCodeCommand request, CancellationToken cancellationToken)
        {
            Response<DeletePinCodeDto> deletePinCodeCommandResponse = null;

            var industry = await _picodeRepsitory.GetByIdAsync(request.PinCodeId);

            if (industry == null)
            {
                return new Response<DeletePinCodeDto>("PinCode not found");
            }

            industry.IsActive = false;
            industry.LastModifiedDate = DateTime.Now;
            await _picodeRepsitory.UpdateAsync(industry);

            var deleteIndustryDto = _mapper.Map<DeletePinCodeDto>(industry);

            return new Response<DeletePinCodeDto>(deleteIndustryDto, "PinCode Deleted Successfully");
        }
    }
}

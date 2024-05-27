using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry
{

    public class DeleteIndustryCommandHandler : IRequestHandler<DeleteIndustryCommand, Response<DeleteIndustryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<Industry> _industryRepsitory;

        public DeleteIndustryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository, IAsyncRepository<Industry> industryRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
            _industryRepsitory = industryRepsitory;
        }

        public async Task<Response<DeleteIndustryDto>> Handle(DeleteIndustryCommand request, CancellationToken cancellationToken)
        {
            Response<DeleteIndustryDto> deleteIndustryCommandResponse = null;

            var industry = await _industryRepsitory.GetByIdAsync(request.IndustryId);

            if (industry == null)
            {
                return new Response<DeleteIndustryDto>("Industry not found");
            }

            industry.IsActive = false;
            industry.LastModifiedDate = DateTime.Now;
            await _industryRepsitory.UpdateAsync(industry);

            var deleteIndustryDto = _mapper.Map<DeleteIndustryDto>(industry);

            return new Response<DeleteIndustryDto>(deleteIndustryDto, "Industry Deleted Successfully");
        }
    }
    
}

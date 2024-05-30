using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateCategory;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry
{
    public class UpdateIndustryCommandHandler :  IRequestHandler<UpdateIndustryCommand, Response<UpdateIndustryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<Industry> _industryRepsitory;

        public UpdateIndustryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository, IAsyncRepository<Industry> industryRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
            _industryRepsitory = industryRepsitory;
        }

        public async Task<Response<UpdateIndustryDto>> Handle(UpdateIndustryCommand request, CancellationToken cancellationToken)
        {
            var industryToUpdate = await _industryRepsitory.GetByIdAsync(request.IndustryId);
            if (industryToUpdate == null)
            {
                return new Response<UpdateIndustryDto>("Industry not found.");
            }
            _mapper.Map(request, industryToUpdate);
            await _industryRepsitory.UpdateAsync(industryToUpdate);
            var updateIndustry = _mapper.Map<UpdateIndustryDto>(industryToUpdate);
            return new Response<UpdateIndustryDto>(updateIndustry, "Industry Updated Successfully");

        }
    }
}

﻿using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;

using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.CreateIndustry
{

    public class CreateIndustryCommandHandler : IRequestHandler<CreateIndustryCommand, Response<CreateIndustryDto>>
    {
        private readonly IMapper _mapper;
       
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<Industry> _industryRepsitory;

        public CreateIndustryCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<Industry> industryRepsitory)
        {
            _mapper = mapper;
            
            _messageRepository = messageRepository;
            _industryRepsitory = industryRepsitory;
        }

        public async Task<Response<CreateIndustryDto>> Handle(CreateIndustryCommand request, CancellationToken cancellationToken)
        {
            Response<CreateIndustryDto> createIndustryCommandResponse = null;

           
                var industry = new Industry() { IndustryName = request.IndustryName, ShortName = request.ShortName, IsActive = request.IsActive };
                industry = await _industryRepsitory.AddAsync(industry);
                createIndustryCommandResponse = new Response<CreateIndustryDto>(_mapper.Map<CreateIndustryDto>(industry), "success");
            

            return createIndustryCommandResponse;
        }
    }
}
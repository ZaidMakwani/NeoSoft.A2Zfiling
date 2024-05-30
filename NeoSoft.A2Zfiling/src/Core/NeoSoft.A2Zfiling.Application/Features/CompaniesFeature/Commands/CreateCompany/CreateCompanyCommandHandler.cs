using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.CreateCompany
{

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Response<CreateCompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<Company> _companyRepsitory;

        public CreateCompanyCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository, IAsyncRepository<Company> companyRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
            _companyRepsitory = companyRepsitory;
        }

        public async Task<Response<CreateCompanyDto>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Response<CreateCompanyDto> createCompanyCommandResponse = null;

            var company = new Company() { CompanyName = request.CompanyName, ShortName = request.ShortName, IsActive = request.IsActive };
            company = await _companyRepsitory.AddAsync(company);
            createCompanyCommandResponse = new Response<CreateCompanyDto>(_mapper.Map<CreateCompanyDto>(company), "success");


            return createCompanyCommandResponse;
        }
    }
}

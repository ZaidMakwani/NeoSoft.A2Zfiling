using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.UpdateCompany
{

    public class UpdateCompanyCommandHandler :  IRequestHandler<UpdateCompanyCommand, Response<UpdateCompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<Company> _companyRepsitory;

        public UpdateCompanyCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository, IAsyncRepository<Company> companyRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
            _companyRepsitory = companyRepsitory;
        }

        public async Task<Response<UpdateCompanyDto>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToUpdate = await _companyRepsitory.GetByIdAsync(request.CompanyId);
            if (companyToUpdate == null)
            {
                return new Response<UpdateCompanyDto>("Company not found.");
            }
            _mapper.Map(request, companyToUpdate);
            await _companyRepsitory.UpdateAsync(companyToUpdate);
            var updateCompany = _mapper.Map<UpdateCompanyDto>(companyToUpdate);
            return new Response<UpdateCompanyDto>(updateCompany, "Company Updated Successfully");

        }
    }
}

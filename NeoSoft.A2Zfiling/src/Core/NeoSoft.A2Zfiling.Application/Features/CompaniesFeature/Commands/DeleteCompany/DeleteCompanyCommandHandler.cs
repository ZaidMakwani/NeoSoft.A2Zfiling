using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.DeleteCompany
{

    public class DeleteCompanyCommandHandler :  IRequestHandler<DeleteCompanyCommand, Response<DeleteCompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<Company> _companyRepsitory;

        public DeleteCompanyCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository, IAsyncRepository<Company> companyRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
            _companyRepsitory = companyRepsitory;
        }

        public async Task<Response<DeleteCompanyDto>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            Response<DeleteCompanyDto> deleteCompanyCommandResponse = null;

            var company = await _companyRepsitory.GetByIdAsync(request.CompanyId);

            if (company == null)
            {
                return new Response<DeleteCompanyDto>("Company not found");
            }

            company.IsActive = false;
            company.LastModifiedDate = DateTime.Now;
            await _companyRepsitory.UpdateAsync(company);

            var deleteCompanyDto = _mapper.Map<DeleteCompanyDto>(company);

            return new Response<DeleteCompanyDto>(deleteCompanyDto, "Company Deleted Successfully");
        }
    }

}

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Userdetails.Queries.GetUserDetailsList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Userdetails.Queries.GetUserDetailsById
{
    public class GetUserDetailByIdHandler : IRequestHandler<GetUserDetailByIdQuery, Response<GetUserDetailByIdDto>>
    {
        private readonly ILogger<GetUserDetailByIdHandler> _logger;
        private readonly IAsyncRepository<UserDetail> _asyncRepository;
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IAsyncRepository<Industry> _industryRepository;
        private readonly IAsyncRepository<State> _stateRepository;
        private readonly IAsyncRepository<City> _cityRepository;
        private readonly IAsyncRepository<MunicipalCorp> _municipalRepositoty;
        private readonly IAsyncRepository<DocumentDetail> _documentDetailRepository;
        private readonly IMapper _mapper;

        public GetUserDetailByIdHandler(ILogger<GetUserDetailByIdHandler> logger, IAsyncRepository<UserDetail> asyncRepository, IMapper mapper,
            IAsyncRepository<Company> companyRepository, IAsyncRepository<Industry> industryRepository, IAsyncRepository<State> stateRepository,
            IAsyncRepository<City> cityRepository, IAsyncRepository<MunicipalCorp> municipalRepositoty, IAsyncRepository<DocumentDetail> documentDetailRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _companyRepository = companyRepository;
            _industryRepository = industryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _municipalRepositoty = municipalRepositoty;
            _documentDetailRepository = documentDetailRepository;
        }
        public async Task<Response<GetUserDetailByIdDto>> Handle(GetUserDetailByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("GetUserDetailsById Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.UserDetailId);
                if (getById == null)
                {
                    return new Response<GetUserDetailByIdDto>("Data not found");
                }
                if (getById.IsActive != true)
                {
                    return new Response<GetUserDetailByIdDto>("Data is not active");
                }

                var userDetail = await _asyncRepository.GetAllIncluding(
                u => u.DocumentDetails
            )
            .Where(u => u.IsActive && u.UserDetailId == request.UserDetailId)
            .FirstOrDefaultAsync();

                if (userDetail == null)
                {
                    return new Response<GetUserDetailByIdDto>("User detail not found");
                }

                var data = new GetUserDetailByIdDto
                {
                    UserDetailId = userDetail.UserDetailId,
                    CompanyName = userDetail.CompanyName,
                    CompanyAddress = userDetail.CompanyAddress,
                    CompanyId = userDetail.CompanyId,
                    Name = _companyRepository.GetByIdAsync(userDetail.CompanyId)?.Result.CompanyName,
                    IndustryId = getById.IndustryId,
                    IndustryName = _industryRepository.GetByIdAsync(userDetail.IndustryId)?.Result.IndustryName,
                    CityId = userDetail.CityId,
                    CityName = _cityRepository.GetByIdAsync(userDetail.CityId)?.Result.CityName,
                    StateId = userDetail.StateId,
                    StateName = _stateRepository.GetByIdAsync(userDetail.StateId)?.Result.StateName,
                    MunicipalId = userDetail.MunicipalId,
                    MunicipalName = _municipalRepositoty.GetByIdAsync(userDetail.MunicipalId)?.Result.MunicipalName,
                    IsActive = userDetail.IsActive,
                    DocumentDetails = userDetail.DocumentDetails.Select(d => new DocumentDetailDto
                    {
                        DocumentDetailId = d.DocumentDetailId,
                        FileName = d.FileName,
                        FileType = d.FileType,
                        IsActive = d.IsActive,
                        DocumentMaster = new DocumentMasterDto
                        {
                            DocumentMasterId = d.DocumentMasterId,
                            //DocumentName = d.DocumentMaster != null ? d.DocumentMaster.DocumentName : null,
                            IsActive = d.IsActive
                        }
                    }).Where(d => d.IsActive == true).ToList()
                };

                _logger.LogInformation("GetUserDetailsById Completed");
                return new Response<GetUserDetailByIdDto>(data, "Data Found Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                var errorMessage = new Response<GetUserDetailByIdDto>(null, $"Error : {ex.Message}");
                return errorMessage;
            }
        
    }
    }
}

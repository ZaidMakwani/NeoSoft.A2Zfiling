using AutoMapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NeoSoft.A2Zfiling.Application.Features.Userdetails.Queries.GetUserDetailsList
{
    public class GetUserDetailsListHandler : IRequestHandler<GetUserDetailsListQuery, Response<IEnumerable<GetUserDetailsListDto>>>
    {
        private readonly ILogger<GetUserDetailsListHandler> _logger;
        private readonly IAsyncRepository<UserDetail> _asyncRepository;
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IAsyncRepository<Industry> _industryRepository;
        private readonly IAsyncRepository<State> _stateRepository;
        private readonly IAsyncRepository<City> _cityRepository;
        private readonly IAsyncRepository<MunicipalCorp> _municipalRepositoty;
        private readonly IAsyncRepository<DocumentDetail> _documentDetailRepository;
        private readonly IMapper _mapper;

        public GetUserDetailsListHandler(ILogger<GetUserDetailsListHandler> logger, IAsyncRepository<UserDetail> asyncRepository, IMapper mapper,
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

        public async Task<Response<IEnumerable<GetUserDetailsListDto>>> Handle(GetUserDetailsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Get All User Uploaded Document Handler Initiated");

                var result = await _asyncRepository.GetAllIncluding(
                       u => u.DocumentDetails 
                   ).Where(u => u.IsActive).ToListAsync();

                if (result == null || !result.Any())
                {
                    return new Response<IEnumerable<GetUserDetailsListDto>>("Data not found");
                }
                var userDetailsDtos = result.Select(u => new GetUserDetailsListDto
                {
                    UserDetailId=u.UserDetailId,
                    CompanyName=u.CompanyName,
                    CompanyAddress=u.CompanyAddress,
                    CompanyId=u.CompanyId,
                    Name = _companyRepository.GetByIdAsync(u.CompanyId)?.Result.CompanyName,
                    IndustryId =u.IndustryId,
                    IndustryName = _industryRepository.GetByIdAsync(u.IndustryId)?.Result.IndustryName,
                    CityId =u.CityId,
                    CityName = _cityRepository.GetByIdAsync(u.CityId)?.Result.CityName,
                    StateId =u.StateId,
                    StateName = _stateRepository.GetByIdAsync(u.StateId)?.Result.StateName,
                    MunicipalId =u.MunicipalId,
                    MunicipalName = _municipalRepositoty.GetByIdAsync(u.MunicipalId)?.Result.MunicipalName,
                    IsActive =u.IsActive,
                    DocumentDetails = u.DocumentDetails.Select(d => new DocumentDetailDto
                    {
                        DocumentDetailId=d.DocumentDetailId,
                        FileName = d.FileName,
                        FileType = d.FileType,
                        IsActive=d.IsActive,
                        DocumentMaster = new DocumentMasterDto
                        {
                            DocumentMasterId = d.DocumentMasterId,
                            //DocumentName = d.DocumentMaster != null ? d.DocumentMaster.DocumentName : null,
                            IsActive=d.IsActive
                        }
                    }).Where(d => d.IsActive == true).ToList()
                }).ToList();

                _logger.LogInformation("Get All User Uploaded Document Handler Completed");

                return new Response<IEnumerable<GetUserDetailsListDto>>(userDetailsDtos, "Data Fetched Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while get all the uploaded document");
                var errorResponse = new Response<IEnumerable<GetUserDetailsListDto>>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}

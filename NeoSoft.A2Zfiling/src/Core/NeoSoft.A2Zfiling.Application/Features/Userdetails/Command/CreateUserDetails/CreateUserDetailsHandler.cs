using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.CreateUserDetails
{
    public class CreateUserDetailsHandler : IRequestHandler<CreateUserDetailsCommand, Response<CreateUserDetailsDto>>
    {
        private readonly ILogger<CreateUserDetailsHandler> _logger;
        private readonly IAsyncRepository<UserDetail> _asyncRepository;
        private readonly IAsyncRepository<DocumentDetail> _documentRepository;
        private readonly IMapper _mapper;

        public CreateUserDetailsHandler(ILogger<CreateUserDetailsHandler> logger, IAsyncRepository<UserDetail> asyncRepository,
           IMapper mapper, IAsyncRepository<DocumentDetail> documentRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _documentRepository = documentRepository;
        }
        public async Task<Response<CreateUserDetailsDto>> Handle(CreateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler User Details Handler Initiated");

				var documentDetails = new List<DocumentDetail>();
                for(int i=0;i<request.FileCollection.Count; i++)
                {
                    var fileName = request.FileCollection[i];
                    var documentMasterId = request.DocumentMasterId[i];
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        var name = Path.GetFileName(fileName);//get only the file name with extension
                        var fileType = Path.GetExtension(fileName); //get the file extension
                        var documenDetail = new DocumentDetail
                        {
                            FileName = fileName,
                            FileType = fileType,
                            IsActive=true,
                            DocumentMasterId=documentMasterId,
                        };
                        documentDetails.Add(documenDetail); 
                    }
                }
                //foreach(var  documentDetail in documentDetails)
                //{
                //    await _documentRepository.AddAsync(documentDetail);
                //}

				var details = new UserDetail
                {
                    CompanyName = request.CompanyName,
                    CompanyAddress = request.CompanyAddress,
                    CompanyId = request.CompanyId,
                    IndustryId = request.IndustryId,
                    CityId = request.CityId,
                    StateId = request.StateId,
                    MunicipalId = request.MunicipalId,
                    DocumentDetails=documentDetails,
                    IsActive=true
                   
                };
                await _asyncRepository.AddAsync(details);
                             
                _logger.LogInformation("Handler User Details Handler Completed");

                var responseDto = _mapper.Map<CreateUserDetailsDto>(details);

                return new Response<CreateUserDetailsDto>(responseDto, "User details created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while uploading documents: {ex.Message}");
                return new Response<CreateUserDetailsDto>($"Error: {ex.Message}");
            }
        }
    }
}

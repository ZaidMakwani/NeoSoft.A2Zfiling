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

                var details = new UserDetail()
                {
                    CompanyName = request.CompanyName,
                    CompanyAddress = request.CompanyAddress,
                    CompanyId = request.CompanyId,
                    IndustryId = request.IndustryId,
                    CityId = request.CityId,
                    StateId = request.StateId,
                    MunicipalId = request.MunicipalId,
                    IsActive=true
                };
                
                var userDetail = _mapper.Map<UserDetail>(details);
                await _asyncRepository.AddAsync(userDetail);

                // Check if files are present in the request
                if (request.FileName == null || request.FileName.Count == 0)
                {
                    return new Response<CreateUserDetailsDto>("No files uploaded or file count is 0.");
                }

                var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                // Create directory if it doesn't exist
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                // List to store responses for uploaded documents
                var uploadInfoResponses = new List<CreateUserDetailsDto>();
                var documentDetails = new List<DocumentDetail>();

                for (int i = 0; i < request.FileName.Count; i++)
                {
                    var uploadFile = request.FileName[i];  // Retrieve the current file
                    var documentMasterId = request.DocumentMasterId[i]; // Retrieve the corresponding document master id for the file

                    var uniqueFileName = Path.GetFileName(uploadFile.FileName); // Get the file name 
                    var filePath = Path.Combine(fileDirectory, uniqueFileName); // Construct the full path to be stored

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(stream);
                    }

                    var documentDetail = new DocumentDetail
                    {
                        FileName = uploadFile.FileName,
                        FileType = Path.GetExtension(uploadFile.FileName),
                        IsActive = true,
                        UserDetailId = userDetail.UserDetailId,
                        DocumentMasterId = documentMasterId,
                        
                    };

                    documentDetails.Add(documentDetail);

                    _logger.LogInformation($"File '{uploadFile.FileName}' uploaded and saved as '{uniqueFileName}' to '{fileDirectory}' on the file system.");
                }
                foreach (var documentDetail in documentDetails)
                {
                    await _documentRepository.AddAsync(documentDetail);
                }
                _logger.LogInformation("Handler User Details Handler Completed");

                var responseDto = _mapper.Map<CreateUserDetailsDto>(userDetail);

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

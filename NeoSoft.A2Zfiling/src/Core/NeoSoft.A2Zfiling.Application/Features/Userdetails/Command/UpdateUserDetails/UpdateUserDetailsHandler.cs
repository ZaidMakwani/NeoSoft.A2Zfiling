using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.CreateUserDetails;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.UpdateUserPermission;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.UpdateUserDetails
{
    public class UpdateUserDetailsHandler : IRequestHandler<UpdateUserDetailsCommand, Response<UpdateUserDetailsDto>>
    {
        private readonly ILogger<UpdateUserDetailsHandler> _logger;
        private readonly IAsyncRepository<UserDetail> _asyncRepository;
        private readonly IAsyncRepository<DocumentDetail> _documentRepository;
        private readonly IMapper _mapper;

        public UpdateUserDetailsHandler(ILogger<UpdateUserDetailsHandler> logger, IAsyncRepository<UserDetail> asyncRepository,
           IMapper mapper, IAsyncRepository<DocumentDetail> documentRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _documentRepository = documentRepository;
        }
        public async Task<Response<UpdateUserDetailsDto>> Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("UpdateUserDetails Handler Initiated");

                var getById = await _asyncRepository.GetAllIncluding(
                    u => u.DocumentDetails)
                    .FirstOrDefaultAsync(u => u.UserDetailId == request.UserDetailId);
                    
                if (getById == null)
                {
                    return new Response<UpdateUserDetailsDto>("User Details not found");
                }
                if (getById.DocumentDetails == null)
                {
                    getById.DocumentDetails = new List<DocumentDetail>();
                    return new Response<UpdateUserDetailsDto>("Document Details is null");
                }
                getById.CompanyName=request.CompanyName;
                getById.CompanyAddress=request.CompanyAddress;
                getById.CompanyId=request.CompanyId;
                getById.IndustryId=request.IndustryId;
                getById.CityId=request.CityId;
                getById.StateId=request.StateId;
                getById.MunicipalId=request.MunicipalId;

               // Directory to store uploaded files
                var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                // Create directory if it doesn't exist
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                // Delete documents that are not updated
                foreach (var documentToDelete in getById.DocumentDetails)
                {
                    documentToDelete.IsActive = false;
                    documentToDelete.LastModifiedBy = "";
                    documentToDelete.LastModifiedDate = DateTime.Now;

                    await _documentRepository.UpdateAsync(documentToDelete);

                    _logger.LogInformation($"Document '{documentToDelete.FileName}' deleted.");
                }

                // Loop through each uploaded file in the request
                foreach (var uploadFile in request.FileName)
                {
                    //if (!request.FileName.Contains(uploadFile.FileName))
                    //{

                    //}
                    var documentMasterId = request.DocumentMasterId[request.FileName.IndexOf(uploadFile)]; // Retrieve the corresponding document master id for the file

                    var uniqueFileName = Path.GetFileName(uploadFile.FileName); // Get the file name 
                    var filePath = Path.Combine(fileDirectory, uniqueFileName); // Construct the full path to be stored

                    // Save the uploaded file to disk
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(stream);
                    }

                    // Check if the file already exists for this user based on DocumentMasterId
                    var existingDocument = getById.DocumentDetails.FirstOrDefault(d =>
                        d.DocumentMasterId == documentMasterId);

                    

                    if (existingDocument != null)
                    {
                        // Update existing document metadata
                         existingDocument.FileName = uploadFile.FileName;
                        existingDocument.FileType = Path.GetExtension(uploadFile.FileName);
                        existingDocument.IsActive = true; // Activate the document if it was previously inactive

                        // Update the document in the repository
                        await _documentRepository.UpdateAsync(existingDocument);
                        _logger.LogInformation($"File '{uploadFile.FileName}' updated and saved as '{uniqueFileName}' to '{filePath}' on the file system.");
                    }
                    else
                    {
                        // Create new document detail if it doesn't exist
                        var newDocumentDetail = new DocumentDetail
                        {
                            FileName = uploadFile.FileName,
                            FileType = Path.GetExtension(uploadFile.FileName),
                            IsActive = true,
                            UserDetailId = getById.UserDetailId,
                            DocumentMasterId = documentMasterId,
                        };

                        // Add new document detail to the repository
                        await _documentRepository.AddAsync(newDocumentDetail);

                        _logger.LogInformation($"File '{uploadFile.FileName}' uploaded and saved as '{uniqueFileName}' to '{filePath}' on the file system.");
                    }
                }

                // Update the UserDetail entity in the repository
                await _asyncRepository.UpdateAsync(getById);
                _logger.LogInformation("Handler User Details Handler Completed");

                    var responseDto = _mapper.Map<UpdateUserDetailsDto>(getById);

                    _logger.LogInformation("UpdateUserDetails Handler Completed");
                return new Response<UpdateUserDetailsDto>(responseDto, "User Details Updated Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                var errorMessage = new Response<UpdateUserDetailsDto>(null, $"Error: {ex.Message}");
                return errorMessage;
            }
        }
    }
}

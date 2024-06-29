using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.DeleteSubStatus;
using NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.CreateUserDetails;
using NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.UpdateUserDetails;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.DeleteUserDetails
{
    public class DeleteUserDetailsHandler : IRequestHandler<DeleteUserDetailsCommand, Response<DeleteUserDetailsDto>>
    {
        private readonly ILogger<DeleteUserDetailsHandler> _logger;
        private readonly IAsyncRepository<UserDetail> _asyncRepository;
        private readonly IAsyncRepository<DocumentDetail> _documentRepository;
        private readonly IMapper _mapper;

        public DeleteUserDetailsHandler(ILogger<DeleteUserDetailsHandler> logger, IAsyncRepository<UserDetail> asyncRepository,
           IMapper mapper, IAsyncRepository<DocumentDetail> documentRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _documentRepository = documentRepository;
        }
        public async Task<Response<DeleteUserDetailsDto>> Handle(DeleteUserDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("DeleteUserDetails Handler Initiated");

                var getById = await _asyncRepository.GetAllIncluding(u => u.DocumentDetails)
                    .FirstOrDefaultAsync(u => u.UserDetailId == request.UserDetailId);

                if (getById == null)
                {
                    return new Response<DeleteUserDetailsDto>("User Details not found");
                }
                if (getById.DocumentDetails == null)
                {
                    getById.DocumentDetails = new List<DocumentDetail>();
                    return new Response<DeleteUserDetailsDto>("Document Details is null");
                }
                getById.IsActive = false;
                getById.LastModifiedBy = "";
                getById.LastModifiedDate = DateTime.Now;

                if(getById.DocumentDetails!=null || getById.DocumentDetails.Any())
                {
                    foreach(var documentDetail in getById.DocumentDetails)
                    {
                        documentDetail.IsActive = false;
                        getById.LastModifiedBy = "";
                        getById.LastModifiedDate = DateTime.Now;

                        await _documentRepository.UpdateAsync(documentDetail);
                    }
                }

                await _asyncRepository.UpdateAsync(getById);

                var deleteData = _mapper.Map<DeleteUserDetailsDto>(getById);
                _logger.LogInformation("DeleteUserDetails Handler Completed");
                return new Response<DeleteUserDetailsDto>(deleteData, "UserDetail Deleted Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data");
                var errorMessage = new Response<DeleteUserDetailsDto>($"Error:{ex.Message}");
                return errorMessage;
            }
        }
    }
}

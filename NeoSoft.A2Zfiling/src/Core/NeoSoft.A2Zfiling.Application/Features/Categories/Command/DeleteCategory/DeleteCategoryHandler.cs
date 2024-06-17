using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.DeleteLicenseType;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Command.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Response<DeleteCategoryDto>>
    {
        private readonly ILogger<DeleteCategoryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _asyncRepository;

        public DeleteCategoryHandler(ILogger<DeleteCategoryHandler> logger, IMapper mapper, IAsyncRepository<Category> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<DeleteCategoryDto>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var getById = await _asyncRepository.GetByIdAsync(request.CategoryId);
                if (getById == null)
                {
                    _logger.LogInformation("Category  not found");
                    return new Response<DeleteCategoryDto>("Category not found.");
                }
                getById.IsActive = false;
                //getById.LastModifiedBy = "";
                getById.LastModifiedDate = DateTime.Now;

                await _asyncRepository.UpdateAsync(getById);

                var deleteLicenseDto = _mapper.Map<DeleteCategoryDto>(getById);
                _logger.LogInformation("Handler Completed");
                return new Response<DeleteCategoryDto>(deleteLicenseDto, "Category  Deleted Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

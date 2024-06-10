using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.UpdateLicenseType;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Command.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Response<UpdateCategoryDto>>
    {
        private readonly ILogger<UpdateCategoryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _asyncRepository;

        public UpdateCategoryHandler(ILogger<UpdateCategoryHandler> logger, IMapper mapper, IAsyncRepository<Category> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<UpdateCategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var getById = await _asyncRepository.GetByIdAsync(request.CategoryId);
                if (getById == null)
                {
                    return new Response<UpdateCategoryDto>("Category  not found.");
                }
                _mapper.Map(request, getById);
                await _asyncRepository.UpdateAsync(getById);
                var data = _mapper.Map<UpdateCategoryDto>(getById);
                _logger.LogInformation("Handler Completed");
                return new Response<UpdateCategoryDto>(data, "Category  Updated Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

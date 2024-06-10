using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeById;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdCommand, Response<GetCategoryByIdDto>>
    {
        private readonly ILogger<GetCategoryByIdHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _asyncRepository;

        public GetCategoryByIdHandler(ILogger<GetCategoryByIdHandler> logger, IMapper mapper, IAsyncRepository<Category> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<GetCategoryByIdDto>> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var getById = (await _asyncRepository.GetByIdAsync(request.CategoryId));
                if (getById == null)
                {
                    return new Response<GetCategoryByIdDto>("Category  not found.");
                }
                if (getById.IsActive != true)
                {
                    return new Response<GetCategoryByIdDto>("This Category  is not Active");
                }
                var data = _mapper.Map<GetCategoryByIdDto>(getById);
                _logger.LogInformation("Handler Completed");
                return new Response<GetCategoryByIdDto>(data, "Data Found Successfully.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

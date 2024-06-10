using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.CreateLicenseType;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Response<CreateCategoryDto>>
    {
        private readonly ILogger<CreateCategoryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _asyncRepository;

        public CreateCategoryHandler(ILogger<CreateCategoryHandler> logger, IMapper mapper, IAsyncRepository<Category> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<CreateCategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");

                var category = new Category()
                {
                    CategoryName = request.CategoryName,
                    ShortName = request.ShortName,
                    IsActive = true,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now,
                };
                var data = await _asyncRepository.AddAsync(category);

                var result = _mapper.Map<CreateCategoryDto>(data);


                _logger.LogInformation("Handler Completed");
                return new Response<CreateCategoryDto>(result, "Category  Inserted Successfully"); ;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

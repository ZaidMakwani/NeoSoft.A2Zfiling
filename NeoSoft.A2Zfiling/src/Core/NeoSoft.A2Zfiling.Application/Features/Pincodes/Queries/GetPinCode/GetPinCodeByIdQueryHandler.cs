using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPicodeList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPinCode
{
    
    public class GetPinCodeByIdQueryHandler : IRequestHandler<GetPinCodeByIdQuery, Response<PinCodeVM>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAsyncRepository<PinCode> _pinCodeRepsitory;
        public GetPinCodeByIdQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, ILogger<GetPinCodeListQueryHandler> logger, IAsyncRepository<PinCode> pinCodeRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
            _pinCodeRepsitory = pinCodeRepsitory;
        }

        public async Task<Response<PinCodeVM>> Handle(GetPinCodeByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var company = (await _pinCodeRepsitory.GetByIdAsync(request.PinCodeId));
            var companyVM = _mapper.Map<PinCodeVM>(company);
            _logger.LogInformation("Hanlde Completed");
            return new Response<PinCodeVM>(companyVM, "success");
        }

    }
}

using Microsoft.EntityFrameworkCore.Internal;
//using NeoSoft.A2Zfiling.Application.Features.ContentService.Query.GettAll;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class ServiceRequest : IServiceRequest
    {
        private readonly IApiClient<ServiceRequestVM> _client;
        public readonly ILogger<RegisteredServices> _logger;

        public ServiceRequest(IApiClient<ServiceRequestVM> client, ILogger<RegisteredServices> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<ServiceRequestVM> ServiceRequestAsync(ServiceRequestVM registerVM)
        {
            _logger.LogInformation("RegisterAsync service is started.");
            var result = await _client.PostAsync("v1/Account/EditServiceRequest", registerVM);
            _logger.LogInformation("RegisterAsync service is completed");
            return result.Data;
        }
        public async Task<ServiceRequestVM> GetServiceRequestAsync()
        {
            _logger.LogInformation("GetAll GetServiceRequestService Initiated");
            var GetServiceRequest = await _client.GetByIdAsync("v1/Account/GetServiceRequest");
            _logger.LogInformation("GetAll Service Completed");

            return GetServiceRequest.Data;
        }

        
    }
}

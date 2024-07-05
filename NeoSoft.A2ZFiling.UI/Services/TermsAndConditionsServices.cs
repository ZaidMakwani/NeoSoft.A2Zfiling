using Microsoft.EntityFrameworkCore.Internal;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class TermsAndConditionsServices: ITermsAndConditionsServices
    {
        private readonly IApiClient<TermsAndConditionsVM> _client;
        public readonly ILogger<RegisteredServices> _logger;

        public TermsAndConditionsServices(IApiClient<TermsAndConditionsVM> client, ILogger<RegisteredServices> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<TermsAndConditionsVM> TermsAndConditionsAsync(TermsAndConditionsVM registerVM)
        {
            _logger.LogInformation("RegisterAsync service is started.");
            var result = await _client.PostAsync("v1/Account/EditTermAndConition", registerVM);
            _logger.LogInformation("RegisterAsync service is completed");
            return result.Data;
        }
        public async Task<TermsAndConditionsVM> GetTermsAndConditionsAsync()
        {
            _logger.LogInformation("GetAll Get TermsAndConditions Service Initiated");
            var GetServiceRequest = await _client.GetByIdAsync("v1/Account/GetTermsAndConditionsss");
            _logger.LogInformation("GetAll Service Completed");

            return GetServiceRequest.Data;
        }
    }
}

using Microsoft.EntityFrameworkCore.Internal;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class AboutUsDetailService : IAboutUsDetailService
    {
        private readonly IApiClient<AboutVM> _client;
        public readonly ILogger<RegisteredServices> _logger;

        public AboutUsDetailService(IApiClient<AboutVM> client, ILogger<RegisteredServices> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<AboutVM> AboutUsDetailAsync(AboutVM registerVM)
        {
            _logger.LogInformation("RegisterAsync service is started.");
            var result = await _client.PostAsync("v1/Account/EditAbout", registerVM);
            _logger.LogInformation("RegisterAsync service is completed");
            return result.Data;
        }
        public async Task<AboutVM> GetAboutUsDetailAsync()
        {
            _logger.LogInformation("GetAll Get TermsAndConditions Service Initiated");
            var GetServiceRequest = await _client.GetByIdAsync("v1/Account/GetAboutDetails");
            _logger.LogInformation("GetAll Service Completed");

            return GetServiceRequest.Data;
        }
    }
}

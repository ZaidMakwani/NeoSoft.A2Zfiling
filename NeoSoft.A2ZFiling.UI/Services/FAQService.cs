using Microsoft.EntityFrameworkCore.Internal;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class FAQService : IFAQService
    {
        private readonly IApiClient<FAQVM> _client;
        public readonly ILogger<RegisteredServices> _logger;

        public FAQService(IApiClient<FAQVM> client, ILogger<RegisteredServices> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<FAQVM> FAQAsync(FAQVM registerVM)
        {
            _logger.LogInformation("FAQAsync service is started.");
            var result = await _client.PostAsync("v1/Account/EditFAQ", registerVM);
            _logger.LogInformation("FAQAsync service is completed");
            return result.Data;
        }
        public async Task<FAQVM> GetFAQAsync()
        {
            _logger.LogInformation("GetAll Get FAQAsync Service Initiated");
            var GetServiceRequest = await _client.GetByIdAsync("v1/Account/GetFAQ");
            _logger.LogInformation("GetAll FAQ Completed");

            return GetServiceRequest.Data;
        }
    }
}

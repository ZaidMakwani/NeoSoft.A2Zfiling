using Microsoft.EntityFrameworkCore.Internal;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class RegisterService:IRegisterService
    {
        private readonly IApiClient<RegisterVM> _client;
        public readonly ILogger<RegisteredServices> _logger;

        public RegisterService(IApiClient<RegisterVM> client, ILogger<RegisteredServices> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<RegisterVM> RegisterAsync(RegisterVM registerVM)
        {
            _logger.LogInformation("RegisterAsync service is started.");
            var result = await _client.PostAsync("v1/Account/Register", registerVM);
            _logger.LogInformation("RegisterAsync service is completed");
            return result.Data;
        }

    }
}

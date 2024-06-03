using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class LoginService:ILoginService
    {
        private readonly IApiClient<LoginVM> _client;
        public readonly ILogger<LoginService> _logger;

        public LoginService(IApiClient<LoginVM> client, ILogger<LoginService> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<LoginVM> LoginAsync(LoginVM loginVM)
        {
            _logger.LogInformation("Login service is started.");
            var result = await _client.PostAsync("v1/Account/Login", loginVM);
            _logger.LogInformation("Login service is completed");
            return result.Data;
        }
    }
}

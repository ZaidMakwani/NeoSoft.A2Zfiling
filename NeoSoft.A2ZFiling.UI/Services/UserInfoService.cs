using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeoSoft.A2ZFiling.UI.Interfaces;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IApiClient<AppUserVM> _client;
        public readonly ILogger<UserInfoService> _logger;

        public UserInfoService(IApiClient<AppUserVM> client, ILogger<UserInfoService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<AppUserVM> GetUserIdByEmailAsync(string email)
        {
            _logger.LogInformation("MyProfile Service initiated");
            var UserId = await _client.GetByIdAsync($"v1/Account/GetUserIdByEmail?Email={email}");

            _logger.LogInformation("MyProfile Service completed");
            return UserId.Data;
        }
    }
}

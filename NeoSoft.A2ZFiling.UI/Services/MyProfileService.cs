using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class MyProfileService : IMyProfileService
    {
        private readonly IApiClient<AppUserVM> _client;
        public readonly ILogger<MyProfileService> _logger;
        public MyProfileService(IApiClient<AppUserVM> client, ILogger<MyProfileService> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<AppUserVM> GetAccountDetailsAsync(string UserId)
        {
            _logger.LogInformation("MyProfile Service initiated");
            var User = await _client.GetByIdAsync($"v1/Account/GetUsers?UserId={UserId}");

            _logger.LogInformation("MyProfile Service completed");
            return User.Data;
        }

        public async Task<AppUserVM> UpdateAccountDetailsAsync(AppUserVM model)
        {
            _logger.LogInformation("MyProfile Service initiated");
            var User = await _client.PutAsync($"v1/Account/UpdateUsers",model);

            _logger.LogInformation("MyProfile Service completed");
            return User.Data;
        }

        public async Task<AppUserVM> UpdatePassword(string UserId, string confirmPassword)
        {
            _logger.LogInformation("MyProfile Service initiated");
            var User = await _client.GetByIdAsync($"v1/Account/UpdatePasswordApi?UserId={UserId}&confirmPassword={confirmPassword}");

            _logger.LogInformation("MyProfile Service completed");
            return User.Data;
        }
    }
}

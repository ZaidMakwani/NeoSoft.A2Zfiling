using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class UserDetailService : IUserDetail
    {
        private readonly ILogger<UserDetailService> _logger;
        private readonly IApiClient<UserDetailVM> _apiClient;

        public UserDetailService(ILogger<UserDetailService> logger, IApiClient<UserDetailVM> apiClient)
        {
            _apiClient = apiClient;
            _logger = logger;
        }
        public async Task<UserDetailVM> CreateUserDetailAsync(UserDetailVM role)
        {
            try
            {
                _logger.LogInformation("Create UserDetail Service Initiated");
                var userDetail = await _apiClient.PostAsync("UserDetail/", role);
                _logger.LogInformation("Create UserDetail Service Initiated");
                return userDetail.Data;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("An error occurred while creating the user details");
                throw ex;
            }
        }
    }
}

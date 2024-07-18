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

		public async Task<UserDetailVM> GetByIdAsync(int id)
		{
			try
			{
				_logger.LogInformation("GetUserDetailById Service Initiated");
				var userDetail = await _apiClient.GetByIdAsync($"UserDetail/id?id={id}");
				_logger.LogInformation("GetUserDetailById Service Completed");
				return userDetail.Data;
			}
			catch (Exception ex)
			{
				_logger.LogError("An error occurred while getting a particular data ");
				throw ex;
			}
		}

		public async Task<IEnumerable<UserDetailVM>> GetUserDetailAsync()
		{
			try
			{
				_logger.LogInformation("GetUserDetail Service Initiated");
				var userDetail = await _apiClient.GetAllAsync("UserDetail/all");
				_logger.LogInformation("GetUserDetail Service Completed");
				return userDetail.Data;
			}
			catch (Exception ex)
			{
				_logger.LogError("An error occurred while retrieving the data ");
				throw ex;
			}
		}
	}
}

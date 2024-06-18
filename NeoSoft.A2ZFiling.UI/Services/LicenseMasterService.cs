using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class LicenseMasterService:ILicenceMasterService
    {
        private readonly IApiClient<LicenseMasterVM> _client;
        public readonly ILogger<LicenseMasterService> _logger;

        public LicenseMasterService(IApiClient<LicenseMasterVM> client, ILogger<LicenseMasterService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<LicenseMasterVM> CreateLicenseMaster(LicenseMasterVM licenseMasterVM)
        {
            _logger.LogInformation("Create License Master service Initiated");
            var license = await _client.PostAsync("v1/LicenseMaster/CreateLicenseMapping", licenseMasterVM);
            _logger.LogInformation("Create License Master service Completed");
            return license.Data;
        }
        public async Task<IEnumerable<LicenseMasterVM>> GetLicenseMasterAsync()
        {
            _logger.LogInformation("GetLicenseMaster Service initiated");
            var License = await _client.GetAllAsync("v1/LicenseMaster/GetAllLicenseMaster");
            
            _logger.LogInformation("GetLicenseMaster Service completed");
            return License.Data;
        }
        public async Task<LicenseMasterVM> UpdateLicenseMasterAsync(LicenseMasterVM license)
        {
            _logger.LogInformation("UpdateLicense Master Service initiated");
            license.IsActive = true;
            license.LastModifiedDate= DateTime.Now;
            var License = await _client.PutAsync("v1/LicenseMaster/UpdateLicenseMaster", license);
            _logger.LogInformation("UpdateLicense Master Service completed");
            return License.Data;

        }
        public async Task<LicenseMasterVM> DisableLicenseMasterAsync(int id)
        {

            _logger.LogInformation("DisableLicenseMasterAsync Service initiated");

            var License = await _client.GetAllAsync("v1/LicenseMaster/GetAllLicenseMaster");

            var licensebyId= License.Data.FirstOrDefault(x=>x.LicenceMasterId==id);
            if (licensebyId.IsActive)
            {
                licensebyId.IsActive = false;
            }
            else
            {
                licensebyId.IsActive = true;
            }
                
                licensebyId.LastModifiedDate= DateTime.Now;
                var LicenseUpdate = await _client.PutAsync("v1/LicenseMaster/UpdateLicenseMaster", licensebyId);
                _logger.LogInformation("DisableLicenseMasterAsync Service completed");
                return LicenseUpdate.Data;
           
        }
    }
}

using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface ILicenceMasterService
    {
       // Task <IEnumerable<LicenseMasterVM>> GetLicenseList();
        Task<LicenseMasterVM> CreateLicenseMaster(LicenseMasterVM licenseMasterVM);
        Task<IEnumerable<LicenseMasterVM>> GetLicenseMasterAsync();
        Task<LicenseMasterVM> UpdateLicenseMasterAsync(LicenseMasterVM license);
        Task<LicenseMasterVM> DisableLicenseMasterAsync(int id);
    }
}

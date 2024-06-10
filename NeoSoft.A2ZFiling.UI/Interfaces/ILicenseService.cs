using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface ILicenseService
    {
        Task<IEnumerable<LicenseVM>> GetLicenseAsync();

        Task<LicenseVM> CreateLicenseAsync(LicenseVM role);

        Task<LicenseVM> DeleteLicenseAsync(int id);

        Task<LicenseVM> GetByIdAsync(int id);

        Task<LicenseVM> UpdateLicenseAsync(LicenseVM role);
    }
}

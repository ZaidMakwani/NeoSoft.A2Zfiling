using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface ILicenseType
    {
        Task<IEnumerable<LicenseTypeVM>> GetLicenseTypeAsync();

        Task<LicenseTypeVM> CreateLicenseTypeAsync(LicenseTypeVM role);

        Task<LicenseTypeVM> DeleteLicenseTypeAsync(int id);

        Task<LicenseTypeVM> GetByIdAsync(int id);

        Task<LicenseTypeVM> UpdateLicenseTypeAsync(LicenseTypeVM role);
    }
}

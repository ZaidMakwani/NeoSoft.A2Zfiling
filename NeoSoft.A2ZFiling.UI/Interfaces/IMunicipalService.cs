using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IMunicipalService
    {
        Task<IEnumerable<MunicipalVM>> GetMunicipalAsync();
        Task<MunicipalVM> CreateMunicipalAsync(MunicipalVM municipal);
        Task<MunicipalVM> GetMunicipalByIdAsync(int id);
        Task<MunicipalVM> UpdateMunicipalAsync(MunicipalVM municipal);
        Task<MunicipalVM> DeleteMunicipalAsync(int id);
    }
}

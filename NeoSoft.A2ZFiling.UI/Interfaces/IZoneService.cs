using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IZoneService
    {
        Task<IEnumerable<ZoneVM>> GetZoneAsync();
        Task<ZoneVM> CreateZoneAsync(ZoneVM role);

        Task<ZoneVM> UpdateZoneAsync(ZoneVM role);

        Task<ZoneVM> DeleteZoneAsync(int id);

        Task<ZoneVM> GetByIdAsync(int id);

       
    }
}

using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityVM>> GetCityAsync();
        Task<IEnumerable<CityVM>> GetCityByStateAsync(int id);
        Task<CityVM> CreateCityAsync(CityVM role);
        Task<CityVM> DeleteCityAsync(int id);

        Task<CityVM> GetByIdAsync(int id);
        Task<CityVM> UpdateCityAsync(CityVM role);

    }
}

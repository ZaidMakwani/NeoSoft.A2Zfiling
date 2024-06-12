using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusVM>> GetStatusAsync();

        Task<StatusVM> CreateStatusAsync(StatusVM role);

        Task<StatusVM> GetByIdAsync(int id);
        Task<StatusVM> UpdateStatusAsync(StatusVM role);

        Task<StatusVM> DeleteStatusAsync(int id);

    }
}

using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface ISubStatusService
    {
        Task<IEnumerable<SubStatusVM>> GetSubStatusAsync();

        Task<SubStatusVM> CreateSubStatusAsync(SubStatusVM role);

        Task<SubStatusVM> GetByIdAsync(int id);

        Task<SubStatusVM> UpdateSubStatusAsync(SubStatusVM role);

        Task<SubStatusVM> DeleteSubStatusAsync(int id);
    }
}

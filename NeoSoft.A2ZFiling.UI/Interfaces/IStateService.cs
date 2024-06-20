using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<StateVM>> GetStateAsync();

        Task<StateVM> CreateStateAsync(StateVM role);
        Task<StateVM> DeleteStateAsync(int id);

        Task<StateVM> GetByIdAsync(int id);
        Task<StateVM> UpdateStateAsync(StateVM role);

    }
}



using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IServiceRequest
    {
        Task<ServiceRequestVM> ServiceRequestAsync(ServiceRequestVM registerVM);
        Task<ServiceRequestVM> GetServiceRequestAsync();

    }
}

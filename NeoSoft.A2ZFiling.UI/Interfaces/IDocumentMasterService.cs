using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IDocumentMasterService
    {
        Task<DocumentMasterVM> CreateDocumentAsync(DocumentMasterVM documentMasterVM);

        //Task<DocumentMasterVM> GetDocumentAsync(int id);
        //Task<DocumentMasterVM> UpdateDocumentAsync(DocumentMasterVM documentMasterVM);
        Task<IEnumerable<DocumentMasterVM>> GetAllDocumentAsync();
        //Task<DocumentMasterVM> DeleteDocumentAsync(int id);
    }
}

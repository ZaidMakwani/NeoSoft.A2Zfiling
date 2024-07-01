using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class DocumentMasterService:IDocumentMasterService
    {
        private readonly IApiClient<DocumentMasterVM> _client;
        public readonly ILogger<DocumentMasterService> _logger;
        public DocumentMasterService(IApiClient<DocumentMasterVM> client, ILogger<DocumentMasterService> logger) {
            _client = client;
            _logger = logger;
        }

        public async Task<IEnumerable<DocumentMasterVM>> GetAllDocumentAsync()
        {
            _logger.LogInformation("GetAll Document is started.");
            var Doc = await _client.GetAllAsync("v1/DocumentMaster/GetAll");
            _logger.LogInformation("GetAll Document is Completed.");
            return Doc.Data;
        }

        public async Task<DocumentMasterVM> CreateDocumentAsync(DocumentMasterVM documentMasterVM)
        {
            _logger.LogInformation("Create Document is started.");
            var Doc = await _client.PostAsync("v1/DocumentMaster/Create",documentMasterVM);
            _logger.LogInformation("Create Document is Completed.");
            return Doc.Data;
        }
    }
}

using MediatR;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;
using NuGet.Protocol;

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
        public async Task<DocumentMasterVM> UpdateDocumentAsync(DocumentMasterVM documentMasterVM)
        {
            _logger.LogInformation("Update Document MAster initiated");
            documentMasterVM.IsActive = true;
            var Doc = await _client.PutAsync("v1/DocumentMaster/Update", documentMasterVM);
            _logger.LogInformation("Update Document Master is successfully completed");
            return Doc.Data;    
        }
        public async Task<DocumentMasterVM> GetDocumentAsync(int id)
        {
            _logger.LogInformation("Get Document master initiated");
            var Doc = await _client.GetByIdAsync($"v1/DocumentMaster/GetById?id={id}");
            _logger.LogInformation("Get Document master Completed");
            return Doc.Data;
        }
        public async Task<DocumentMasterVM> DeleteDocumentAsync(int id)
        {
            _logger.LogInformation("Delete Master initiated");
            //var doc = await _client.GetByIdAsync($"v1/DocumentMaster/GetById?id={id}");
            var docAll = await _client.GetAllAsync("v1/DocumentMaster/GetAll");
            var doc = docAll.Data.FirstOrDefault(x => x.DocumentMasterId == id);
            if (doc == null)
            {
                return null;
            }
            if (doc.IsActive)
            {
                doc.IsActive = false;
            }
            else
            {
                doc.IsActive = true;
            }
            var Doc = await _client.PutAsync("v1/DocumentMaster/Update", doc);

            _logger.LogInformation($"{id} deleted");
            return Doc.Data;
        }


    }
}

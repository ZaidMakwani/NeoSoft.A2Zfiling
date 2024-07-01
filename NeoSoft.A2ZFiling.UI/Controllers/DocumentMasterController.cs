using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class DocumentMasterController : Controller
    {
        private readonly ILogger<DocumentMasterController> _logger;
        private readonly IDocumentMasterService _documentMasterService;
        public DocumentMasterController(ILogger<DocumentMasterController> logger, IDocumentMasterService documentMasterService)
        {
            _logger = logger;
            _documentMasterService = documentMasterService;
        }

        public async Task<IActionResult> GetAllList()
        {
            var result = await _documentMasterService.GetAllDocumentAsync();
             return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create() {

            return PartialView("_PartialCreateDocument");
        }
        [HttpPost]
        public async Task<IActionResult> Create(DocumentMasterVM documentMasterVM)
        {
            _logger.LogInformation("Create Document Master is Initiated");
            var isExist=  _documentMasterService.GetAllDocumentAsync().Result.Where(x=>x.DocumentName==documentMasterVM.DocumentName);
            if (isExist.Any())
            {
                return BadRequest("Already Exists!!");
            }
            else
            {
                var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "SampleFormat");

                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                var filePath = Path.Combine(fileDirectory, documentMasterVM.SampleFormatFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await documentMasterVM.SampleFormatFile.CopyToAsync(stream)
    ;
                }
                documentMasterVM.SampleFormat = Path.Combine("SampleFormat",documentMasterVM.SampleFormatFile.FileName);
                documentMasterVM.DocumentFormat = String.Join(",", documentMasterVM.DocumentFormatList);
                var response= await _documentMasterService.CreateDocumentAsync(documentMasterVM);
            }
            return Json(new { success = true, message = "Document created successfully." });
        }
    }
}

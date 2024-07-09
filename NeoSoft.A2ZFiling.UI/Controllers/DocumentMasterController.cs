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
            if (string.IsNullOrEmpty(documentMasterVM.DocumentName))
            {
                return BadRequest("Document Name is Required");
            }
            if (documentMasterVM.SampleFormatFile ==null)
            {
                return BadRequest("Sample Document is Required");
            }
            if (documentMasterVM.DocumentFormatList ==null)
            {
                return BadRequest("Select atleast one option");
            }

            var isExist = _documentMasterService.GetAllDocumentAsync().Result.Where(x => x.DocumentName == documentMasterVM.DocumentName);
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
                    documentMasterVM.IsActive = true;
                    documentMasterVM.SampleFormat = Path.Combine("SampleFormat", documentMasterVM.SampleFormatFile.FileName);
                    documentMasterVM.DocumentFormat = String.Join(",", documentMasterVM.DocumentFormatList);
                    var response = await _documentMasterService.CreateDocumentAsync(documentMasterVM);
                }
                return Json(new { success = true, message = "Document created successfully." });
            }
        
       
        

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _documentMasterService.GetDocumentAsync(id);
            if (result != null)
            {
                result.DocumentFormatList = result.DocumentFormat.Split(',').ToList();

                return PartialView("_PartialDocumentMasterUpdate", result);
            }
            else
            {
                //return Json(new { success = false, message = "Not an Active." });
                return NotFound("Not an Active");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(DocumentMasterVM documentMasterVM)
        {
            if (string.IsNullOrEmpty(documentMasterVM.DocumentName))
            {
                return BadRequest("Document Name is Required");
            }
            if (documentMasterVM.DocumentFormatList == null)
            {
                return BadRequest("Select atleast one option");
            }
            var documentById= await _documentMasterService.GetDocumentAsync(documentMasterVM.DocumentMasterId);

            var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "SampleFormat");

            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            if (documentMasterVM.SampleFormatFile != null)
            {
                var filePath = Path.Combine(fileDirectory, documentMasterVM.SampleFormatFile.FileName);
                var alreadyfilePath = Path.Combine(fileDirectory, documentById.SampleFormat);
                if (alreadyfilePath == filePath)
                {
                    System.IO.File.Delete(alreadyfilePath);
                }
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await documentMasterVM.SampleFormatFile.CopyToAsync(stream);
                }
                documentMasterVM.SampleFormat = Path.Combine("SampleFormat", documentMasterVM.SampleFormatFile.FileName);
            }
            else
            {
                documentMasterVM.SampleFormat = Path.Combine("SampleFormat", documentById.SampleFormat.Split("\\")[1]);
            }
                documentMasterVM.IsActive = true;
                documentMasterVM.DocumentFormat = String.Join(",", documentMasterVM.DocumentFormatList);
            
           
            var result= await _documentMasterService.UpdateDocumentAsync(documentMasterVM);
            return Json( new {success = true, message = "Success"});
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result= await _documentMasterService.DeleteDocumentAsync(id);
            return RedirectToAction("GetAllList");
        }
    }
}

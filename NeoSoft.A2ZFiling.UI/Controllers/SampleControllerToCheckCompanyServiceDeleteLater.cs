using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class SampleControllerToCheckCompanyServiceDeleteLater : Controller
    {
        private readonly ICompanyService _companyService;
        public SampleControllerToCheckCompanyServiceDeleteLater(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new CompanyVM()
            {
                CompanyId = 4,
                CompanyName = "Neosoft",
                ShortName = "Test",
                IsActive = true,
            };

            //var result = await _companyService.CreateCompanyAsync(model);
            var result2 = await _companyService.UpdateCompanyAsync(model);
            var result3 = await _companyService.GetByIdAsync(4);
            var result4 = await _companyService.GetCompanyAsync();
            var result5 = await _companyService.DeleteCompanyAsync(4);
            return View();
        }
    }
}

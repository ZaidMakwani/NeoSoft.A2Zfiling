using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Filter;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tables()
        {
            return View();
        }

        public IActionResult LicenseConfigurationSetting()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class ExecutiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddFieldExecutive()
        {  
            IEnumerable<NeoSoft.A2ZFiling.UI.ViewModels.FieldExecutiveVM> model = null;           

            return View(model);
        }
    }
}
  
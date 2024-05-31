using Microsoft.AspNetCore.Mvc;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
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
    }
}

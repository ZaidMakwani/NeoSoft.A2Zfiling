using Microsoft.AspNetCore.Mvc;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PaymentOption()
        {
            return View();
        }
        public IActionResult CreditCard()
        {
            return View();
        }
        public IActionResult NetBanking()
        {
            return View();
        }
        public IActionResult UPI()
        {
            return View();
        }
        public IActionResult Wallet()
        {
            return View();
        }

    }
}

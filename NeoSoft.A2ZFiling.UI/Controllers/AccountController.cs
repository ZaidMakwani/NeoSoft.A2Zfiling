using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeosoftA2Zfilings.Views.Controllers
{
    public class AccountController : Controller
    {

        Uri baseAddres = new Uri("https://localhost:5000/api");
        private readonly HttpClient _client;
        private readonly IDNTCaptchaValidatorService _captchaValidator;

        public AccountController(IDNTCaptchaValidatorService captchaValidator)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddres;

            _captchaValidator = captchaValidator;

        }

        public IActionResult Login()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                if (!_captchaValidator.HasRequestValidCaptchaEntry())
                {  
                    TempData["captchaError"] = "Please enter valid security key";
                    return View(model);
                }

                // Add your login logic here

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}

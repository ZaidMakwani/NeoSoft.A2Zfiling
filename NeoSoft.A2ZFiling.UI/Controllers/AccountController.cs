using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;
using Newtonsoft.Json;

namespace NeosoftA2Zfilings.Views.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegisterService _registerService;
        private readonly ILogger<AccountController> _logger;
        private readonly IDNTCaptchaValidatorService _captchaValidator;
        public AccountController(IRegisterService registerService, ILogger<AccountController> logger, IDNTCaptchaValidatorService captchaValidator)
        {
            _registerService = registerService;
            _logger = logger;
            _captchaValidator = captchaValidator;
        }
        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterVM model)
        {
            //string data = JsonConvert.SerializeObject(model);
            //StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            _logger.LogInformation("Registration is initiated");
           var response = await _registerService.RegisterAsync(model);
            if (response!=null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
            
        }
    }
}

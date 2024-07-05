using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using NeosoftA2Zfilings.Views.ViewModels;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NeoSoft.A2Zfiling.Persistence.Repositories;
using Microsoft.AspNetCore.Hosting;
using NuGet.Common;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2ZFiling.UI.Services;
using System.Net.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web.WebPages;
using System.Data;


namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class AccountController : Controller
    {


        //private readonly HttpClient _client;
        private readonly IDNTCaptchaValidatorService _captchaValidator;
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;
        private readonly ILogger<AccountController> _logger;
        private readonly IServiceRequest _serviceRequest;
        //private readonly ITokenRepository _tokenRepository;
        private readonly ITermsAndConditionsServices _termsAndConditionsServices;
        private readonly IAboutUsDetailService _aboutUsDetailService;
        private readonly IFormService _formService;
        private readonly IFAQService _faQService;
        private readonly HttpClient _client;
        Uri baseAddress = new Uri("https://localhost:5000/api");

        public AccountController(IRegisterService registerService, ILogger<AccountController> logger,
            IDNTCaptchaValidatorService captchaValidator, ILoginService loginService /*,ITokenRepository tokenRepository*/, IServiceRequest serviceRequest, ITermsAndConditionsServices termsAndConditionsServices , IAboutUsDetailService aboutUsDetailService,IFAQService fAQService, IFormService formService)
        {
            _registerService = registerService;
            _logger = logger;
            _captchaValidator = captchaValidator;
            _loginService = loginService;
            _serviceRequest = serviceRequest;
            //_tokenRepository = tokenRepository;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _termsAndConditionsServices = termsAndConditionsServices;
            _aboutUsDetailService = aboutUsDetailService;
            _faQService = fAQService;
            _formService = formService;





        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                if (!_captchaValidator.HasRequestValidCaptchaEntry())
                {
                    TempData["captchaError"] = "Please enter valid security key";
                    return View(model);
                }

                _logger.LogInformation("Login is initiated");
                model.Expiration = DateTime.Now;
                model.RefreshToken = " ";
                //model.Token = " ";

                var response = await _loginService.LoginAsync(model);

                if (response != null)
                {
                    // Retrieve token value based on some criteria (e.g., user ID)
                    var token = response.Token;

                    if (!string.IsNullOrEmpty(token))
                    {
                        HttpContext.Session.SetString("Token", token);

                        _logger.LogInformation("Token value: {TokenValue}", token);
                        TempData["token"] = "token";
                        return RedirectToAction("Index", "Account");

                    }

                    // Handle token retrieval failure
                }

                // Handle login response being null
            }

            TempData["login"] = "Login Failed. Wrong Password!";

            // Handle invalid ModelState
            return View(model);
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

            var webHostEnvironment = HttpContext.RequestServices.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;

            string webRootPath = webHostEnvironment.WebRootPath;
            string uploadsFolder = Path.Combine(webRootPath, "images");

            // Check and create the directory if it doesn't exist
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = null;

            if (model.ProfilePicture != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfilePicture.CopyToAsync(fileStream);
                }
            }

            model.ProfileImagePath = uniqueFileName != null ? $"/images/{uniqueFileName}" : null;


            var response = await _registerService.RegisterAsync(model);
            if (response != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

            //return RedirectToAction("Index", "Account");
        }

        public IActionResult Logout()
        {
            var token = HttpContext.Session.GetString("Token");
            _logger.LogInformation($"Token before clearing: {token}");
            HttpContext.Session.Clear();
            _logger.LogInformation($"Token after clearing: {HttpContext.Session.GetString("Token")}");
            TempData.Remove("token");
            return RedirectToAction("Index", "Account");

        }
        [HttpGet]
        public IActionResult GenerateNewCaptcha()
        {
            return PartialView("_CaptchaPartial");
        }

       

       
      

        [HttpPost]
        public async Task<IActionResult> CreateServiceRequest(ServiceRequestVM model)
        {

            var response = await _serviceRequest.ServiceRequestAsync(model);

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetallServiceRequest()
        {
            var response = await _serviceRequest.GetServiceRequestAsync();
            //return View("GetallServiceRequest", response);
            return View(response);
        }
        [HttpGet]
        public async Task<IActionResult> TermsOfUse()
        {
            var response = await _termsAndConditionsServices.GetTermsAndConditionsAsync();
            var token = HttpContext.Session.GetString("Token");

            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();

                // Validate the token if needed here
                var jwtToken = handler.ReadJwtToken(token);

                //var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role").Value;
                var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
                TempData["Role"] = role;
            }
            else
            {
                TempData["Role"] = "Null";
            }

            return View(response);
        }
        [HttpGet]
        public async Task<IActionResult> EditTnC()
        {
            var response = await _termsAndConditionsServices.GetTermsAndConditionsAsync();
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> EditTnC(string htmlContent)
        
        {
            var content = new TermsAndConditionsVM
            {
                TermsDescrption = htmlContent
            };
            var response = await _termsAndConditionsServices.TermsAndConditionsAsync(content);

            return RedirectToAction("TermsOfUse");
        }
        [HttpGet]
        public async Task< IActionResult> AboutUs()
        {
            var response = await _aboutUsDetailService.GetAboutUsDetailAsync();
            var token = HttpContext.Session.GetString("Token");

            if(token != null) 
            {
                var handler = new JwtSecurityTokenHandler();

                // Validate the token if needed here
                var jwtToken = handler.ReadJwtToken(token);

                //var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role").Value;
                var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
                TempData["Role"] = role;
            }
            else
            {
                TempData["Role"] = "Null";
            }

            return View(response);
        }
        [HttpGet]
        public async Task<IActionResult> EditAboutUs()
        {
            var response = await _aboutUsDetailService.GetAboutUsDetailAsync();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> EditAboutUs(string htmlContent)

        {
            var content = new AboutVM
            {
                About = htmlContent
            };
            var response = await _aboutUsDetailService.AboutUsDetailAsync(content);

            return RedirectToAction("AboutUs");
        }
        public async Task< IActionResult> FAQ()
        {
            var responce = await _faQService.GetFAQAsync();
            var token = HttpContext.Session.GetString("Token");

            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();

                // Validate the token if needed here
                var jwtToken = handler.ReadJwtToken(token);

                //var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role").Value;
                var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
                TempData["Role"] = role;
            }
            else
            {
                TempData["Role"] = "Null";
            }
            return View(responce);
        } 
        [HttpGet]
        public async Task<IActionResult> EditFAQ()
        {
            var response = await _faQService.GetFAQAsync();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> EditFAQ(string htmlContent)

        {
            var content = new FAQVM
            {
                FaqDescription = htmlContent
            };
            var response = await _faQService.FAQAsync(content);

            return RedirectToAction("FAQ");
        }
        [HttpGet]
        public async Task< IActionResult> ContactUs()
        {
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUSVM model)
        {
            try
            {
                _logger.LogInformation("Create  Action Initiated");

               
                var response = await _formService.CreateFormAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to create Form: Response was null.");
                    return BadRequest("Failed to create Form.");
                }
                else
                {
                    _logger.LogInformation("Create Form Action Completed");
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating Form.");
                return StatusCode(500, "An error occurred while creating Form.");
            }
        }
        public async Task<IActionResult> GetAllMessagesList()
        {
            var responce = await _formService.GetFormAsync();
            return View(responce);
        }
        public async Task<IActionResult> Update(int Id)
        {
            var response = await _formService.GetByIdAsync(Id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Update(ContactUSVM model)
        {
            if (string.IsNullOrEmpty(model.YourName))
            {
                return BadRequest("Please enter a  name.");
            }
            if (model.YourName.Any(char.IsDigit))
            {
                return BadRequest(" Name cannot contain numbers.");
            }
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Account/Update/", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }

            return View();
        }


    }
}

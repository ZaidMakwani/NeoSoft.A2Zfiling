using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.ViewModels;
using System.Net.Mail;
using System.Net;
using Twilio.Types;
using Twilio;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class ServiceRegistrationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string accountSid = "ACa217336b6f13ecd2ba825f26cdc9f952";
        private readonly string authToken = "63d862f8332758153ab11b4afb0637d8";
        private readonly string fromPhoneNumber = "+17178825643";

        public ServiceRegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult FSSAIRegistration()
        {
            return View("FSSAIRegistration");
        }

        public IActionResult CompanyRegistration()
        {
            return View("CompanyRegistration");
        }

        public IActionResult BuisnessSetupRegistration()
        {
            return View("BusinessSetupRegistration");
        }

        [HttpPost]
        public IActionResult SendOtp(OtpRequest model)
        {
            if (!string.IsNullOrWhiteSpace(model.MobileNumber))
            {
                TwilioClient.Init(accountSid, authToken);
                string otp = GenerateOtp();
                SendOtp("+91"+model.MobileNumber, otp);
                ViewBag.Message = $"OTP sent to {model.MobileNumber}";

                TempData["OTP"] = otp;
                TempData["MobileNumber"] = model.MobileNumber;

                return PartialView("_OtpInputPartial", model);
            }
            else
            {
                ViewBag.Message = "Invalid Mobile number";
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult VerifyOtp(OtpResponse model)
        {
            string storedOtp = TempData["OTP"] as string;
            string storedMobileNumber = TempData["MobileNumber"] as string;

            if (model.Otp == storedOtp)
            {
                ViewBag.Message = "OTP verified successfully!";
            }
            else
            {
                ViewBag.Message = "Invalid OTP.";
            }
            return View("Index");
        }


        private string GenerateOtp()
        {
            // Generate a 6-digit OTP
            Random rand = new Random();
            int otp = rand.Next(100000, 999999);
            return otp.ToString();
        }

        private void SendOtp(string toPhoneNumber, string otp)
        {
            MessageResource.Create(
                body: $"Your OTP is {otp}",
                from: new PhoneNumber(fromPhoneNumber),
                to: new PhoneNumber(toPhoneNumber)
            );
        }

    }
}

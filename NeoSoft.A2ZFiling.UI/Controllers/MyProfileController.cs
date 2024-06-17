using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class MyProfileController : Controller
    {
        private readonly IMyProfileService _myProfileService;

        public MyProfileController(IMyProfileService myProfileService)
        {
            _myProfileService = myProfileService;
        }
        public async Task<IActionResult> Index()
        {

            var token = HttpContext.Session.GetString("Token");

            if (string.IsNullOrEmpty(token))
            {
                // Token not found in session
                return BadRequest();
            }

            else
            {
                // Token found in session
                // Perform other operations with the token as needed

                ClaimsPrincipal claimsPrincipal = JwtDecoder.DecodeJwtToken(token);

                foreach (var claim in claimsPrincipal.Claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }


                var userClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "userId");
                var userId = userClaim.Value;

                var response = await _myProfileService.GetAccountDetailsAsync(userId);

                var model = new CombinedViewModel
                {
                    AppUser = response,
                    Password = new PasswordVM()
                };

               

                return View(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ComparePassword(PasswordVM model)
        {
            string currentPassword = model.CurrentPassword;
            string newPassword = model.NewPassword;
            string confirmPassword = model.ConfirmPassword;

            // Retrieve password from TempData
            var storedPassword = model.PasswordCurr;

            // Check if the current password matches the stored password
            if (model.CurrentPassword != storedPassword)
            {
                // Current password does not match the stored password
                ModelState.AddModelError(nameof(model.CurrentPassword), "Current password is incorrect.");
                return RedirectToAction("Index", "MyProfile");
            }

            // Check if the new password is the same as the old password
            if (model.NewPassword == storedPassword)
            {
                // New password is the same as the old password
                ModelState.AddModelError(nameof(model.NewPassword), "The new password should not be the same as the old password.");
                return RedirectToAction("Index", "MyProfile");
            }

            // If both checks pass, update the password (replace this with your actual logic)
            // Here, you can update the password using your data access layer or Identity framework
            var token = HttpContext.Session.GetString("Token");

            if (string.IsNullOrEmpty(token))
            {
                // Token not found in session
                return BadRequest();
            }

            else
            {
                // Token found in session
                // Perform other operations with the token as needed

                ClaimsPrincipal claimsPrincipal = JwtDecoder.DecodeJwtToken(token);

                foreach (var claim in claimsPrincipal.Claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }


                var userClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "userId");
                var userId = userClaim.Value;

                var response = await _myProfileService.UpdatePassword(userId, confirmPassword);

                TempData["SuccessMessage"] = "Password updated successfully.";
                return RedirectToAction("Index", "MyProfile");

                //return View(response);
            }


            // Return a success message or redirect to another action
           

        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(AppUserVM model)
         {

            //if (!ModelState.IsValid) 
            //{
            //    return View(model);
            //}

            var token = HttpContext.Session.GetString("Token");

            if (string.IsNullOrEmpty(token))
            {
                // Token not found in session
                return BadRequest();
            }

            else
            {
                // Token found in session
                // Perform other operations with the token as needed

                ClaimsPrincipal claimsPrincipal = JwtDecoder.DecodeJwtToken(token);

                foreach (var claim in claimsPrincipal.Claims)
                {
                    Console.WriteLine($"{claim.Type}: {claim.Value}");
                }


                var userClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "userId");
                var userId = userClaim.Value;

                model.AppUserId = userId;

                var response = await _myProfileService.UpdateAccountDetailsAsync(model);

                TempData["SuccessMessage"] = "User Updated Successfully";

                return RedirectToAction("Index", "MyProfile");
            }
        }
    }
}

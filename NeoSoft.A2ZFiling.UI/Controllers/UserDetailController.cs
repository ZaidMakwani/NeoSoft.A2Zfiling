using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.CreateUserDetails;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
	public class UserDetailController : Controller
	{
		private readonly ILogger<UserDetailController> _logger;
		private readonly IIndustryService _industryService;
		private readonly ICityService _cityService;
		private readonly IStateService _stateService;
		private readonly IMunicipalService _municipalService;
		private readonly IDocumentMasterService _documentMasterService;
		private readonly IUserDetail _userDetail;
		private readonly ICompanyService _companyService;


		public UserDetailController(ILogger<UserDetailController> logger, IIndustryService industryService,
			ICityService cityService, IStateService stateService, IMunicipalService municipalService, IDocumentMasterService documentMasterService, IUserDetail userDetail,
			ICompanyService companyService)
		{
			_logger = logger;
			_industryService = industryService;
			_cityService = cityService;
			_stateService = stateService;
			_municipalService = municipalService;
			_documentMasterService = documentMasterService;
			_userDetail = userDetail;
			_companyService = companyService;
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			try
			{
				var industry = _industryService.GetIndustryAsync();
				ViewBag.Industries = new SelectList(industry, "IndustryId", "IndustryName");
				var company = await _companyService.GetCompanyAsync();
				ViewBag.Companies = new SelectList(company, "CompanyId", "CompanyName");
				var city = await _cityService.GetCityAsync();
				ViewBag.Cities = new SelectList(city, "CityId", "CityName");
				var state = await _stateService.GetStateAsync();
				ViewBag.States = new SelectList(state, "StateId", "StateName");
				var municipal = await _municipalService.GetMunicipalAsync();
				ViewBag.Municipalies = new SelectList(municipal, "MunicipalId", "MunicipalName");
				var documentName = await _documentMasterService.GetAllDocumentAsync();
				ViewBag.DocumentName = new SelectList(documentName, "DocumentMasterId", "DocumentName");
				return View();
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create(UserDetailVM model)
		{
			try
			{
				var industry = _industryService.GetIndustryAsync();
				ViewBag.Industries = new SelectList(industry, "IndustryId", "IndustryName");
				var company = await _companyService.GetCompanyAsync();
				ViewBag.Companies = new SelectList(company, "CompanyId", "CompanyName");
				var city = await _cityService.GetCityAsync();
				ViewBag.Cities = new SelectList(city, "CityId", "CityName");
				var state = await _stateService.GetStateAsync();
				ViewBag.States = new SelectList(state, "StateId", "StateName");
				var municipal = await _municipalService.GetMunicipalAsync();
				ViewBag.Municipalies = new SelectList(municipal, "MunicipalId", "MunicipalName");
				var documentName = await _documentMasterService.GetAllDocumentAsync();
				ViewBag.DocumentName = new SelectList(documentName, "DocumentMasterId", "DocumentName");

				if (ModelState.IsValid)
				{
					var existingCategory = (await _userDetail.GetUserDetailAsync()).Where(x => x.CompanyName.ToLower() == model.CompanyName.ToLower()).FirstOrDefault();
					if (existingCategory != null)
					{
						ModelState.AddModelError("", "Company name with this name already exists.");
						return View(model);
					}

					// Check if files are present in the request
					if (model.FileName == null || model.FileName.Count == 0)
					{
						return BadRequest("No files uploaded or file count is 0.");
					}

					//var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

					var fileDirectory = Path.Combine("wwwroot", "uploads");

					// Create directory if it doesn't exist
					if (!Directory.Exists(fileDirectory))
					{
						Directory.CreateDirectory(fileDirectory);
					}
					// List to store responses for uploaded documents
					model.FileCollection = new List<string>();
					for (int i = 0; i < model.FileName.Count; i++)
					{
						var uploadFile = model.FileName[i];  // Retrieve the current file
						var documentMasterId = model.DocumentMasterId[i]; // Retrieve the corresponding document master id for the file

						var uniqueFileName = Path.GetFileName(uploadFile.FileName); // Get the file name 
						var filePath = Path.Combine(fileDirectory, uniqueFileName); // Construct the full path to be stored

						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await uploadFile.CopyToAsync(stream);
						}
						model.FileCollection.Add(filePath);
					}
					model.IsActive = true;
					var response = await _userDetail.CreateUserDetailAsync(model);
					if (response == null)
					{
						_logger.LogError("Failed to create user detail : Response was null.");
						return BadRequest("Failed to create user detail .");
					}
					else
					{
						_logger.LogInformation("Create User Detail Action Completed");
						//return Ok(response);
						return RedirectToActionPermanent("Index", "Home");
						//return Ok(new {response, success = true, message = "User Detail created successfully." });

					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while creating user detail .");
				//return StatusCode(500, "An error occurred while creating user detail .");
				return RedirectToAction("Create", "UserDetail");
			}
			return View(model);
		}
	}
}



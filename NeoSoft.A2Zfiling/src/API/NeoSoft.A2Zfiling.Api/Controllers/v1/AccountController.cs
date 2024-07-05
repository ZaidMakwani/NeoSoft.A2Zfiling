using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Register.Command;
using LoginCommand = NeoSoft.A2Zfiling.Application.Features.Login.Command.LoginCommand;
using NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries;
using NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Commands;
using NeoSoft.A2Zfiling.Application.Features.Login.Command;
using NeoSoft.A2Zfiling.Application.Features.ContentService.Command.Edit;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList;
using NeoSoft.A2Zfiling.Application.Features.ContentService.Query.GettAll;
using NeoSoft.A2Zfiling.Application.Features.TermsAndConditions.Query.GetAll;
using NeoSoft.A2Zfiling.Application.Features.TermsAndConditions.Commands.Edit;
using NeoSoft.A2Zfiling.Application.Features.AboutUs.Query.GetAll;
using NeoSoft.A2Zfiling.Application.Features.AboutUs.Command.Edit;
using NeoSoft.A2Zfiling.Application.Features.FAQFeatures.Query.GetAll;
using NeoSoft.A2Zfiling.Application.Features.FAQFeatures.Command.Edit;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateList;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.CreateState;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.UpdateState;
using NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Command.SubmitForm;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity;
using NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Query.GetAllMessagees;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateById;
using NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Query.GetMessagesById;
using NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Command.UpdateForm;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    //[Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class AccountController : ControllerBase
    {

        private readonly IMediator _mediator;

        private readonly ILogger<AccountController> _logger;


        public AccountController(IMediator mediator, ILogger<AccountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            try
            {
                _logger.LogInformation("Register Member Initiated");
                var response = await _mediator.Send(registerCommand);
                _logger.LogInformation("Register Member Completed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginCommand loginCommand)

        {

            _logger.LogInformation("Login Initiated");
            var response = await _mediator.Send(loginCommand);
            _logger.LogInformation("Login Completed");
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers(string UserId)
        {

            _logger.LogInformation("Login Initiated");
            var response = await _mediator.Send(new GetUsersDetailQuery() { UserId = UserId });

            _logger.LogInformation("Login Completed");
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> UpdatePasswordApi(string UserId, string confirmPassword)
        {

            _logger.LogInformation("Login Initiated");
            var response = await _mediator.Send(new UpdatePasswordApiQuery() { UserId = UserId, ConfirmPassword = confirmPassword });

            _logger.LogInformation("Login Completed");
            return Ok(response);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateUsers(UpdateUsersCommand updateUsersCommand)
        {
            _logger.LogInformation("Login Initiated");
            var response = await _mediator.Send(updateUsersCommand);

            _logger.LogInformation("Login Completed");
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> EditServiceRequest(ContentServiceEditCommand contentServiceEditCommand)
        {


            _logger.LogInformation("Service Initiated");
            var response = await _mediator.Send(contentServiceEditCommand);
            _logger.LogInformation("Service Completed");
            return Ok(response);

        }

        [HttpGet]
        public async Task<ActionResult> GetServiceRequest()
        {
            try
            {
                _logger.LogInformation("GetAll Service request Initiated");
                var data = await _mediator.Send(new ServiceRequestQuery());
                _logger.LogInformation("Service request Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetTermsAndConditionsss()
        {
            try
            {
                _logger.LogInformation("GetAll TermsAndConditionsss Initiated");
                var data = await _mediator.Send(new GetAllTermsAndConditionsQuery());
                _logger.LogInformation("Service request Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditTermAndConition(TermAndConitionEditCommand contentServiceEditCommand)
        {


            _logger.LogInformation("Service Initiated");
            var response = await _mediator.Send(contentServiceEditCommand);
            _logger.LogInformation("Service Completed");
            return Ok(response);

        }
        [HttpGet]
        public async Task<ActionResult> GetAboutDetails()
        {
            try
            {
                _logger.LogInformation("GetAll AboutDetails Initiated");
                var data = await _mediator.Send(new GetAllAboutQuery());
                _logger.LogInformation("Service request Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<ActionResult> EditAbout(AboutEditCommand contentServiceEditCommand)
        {


            _logger.LogInformation("Service Initiated");
            var response = await _mediator.Send(contentServiceEditCommand);
            _logger.LogInformation("Service Completed");
            return Ok(response);

        }
        [HttpGet]
        public async Task<ActionResult> GetFAQ()
        {
            try
            {
                _logger.LogInformation("GetAll FAQ Initiated");
                var data = await _mediator.Send(new GetAllFAQQuery());
                _logger.LogInformation("Service request Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<ActionResult> EditFAQ(FAQEditCommand contentServiceEditCommand)
        {


            _logger.LogInformation("Service Initiated");
            var response = await _mediator.Send(contentServiceEditCommand);
            _logger.LogInformation("Service Completed");
            return Ok(response);

        }
        [HttpGet("all", Name = "GetAllContactMessage")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllContactMessage()
        {
            _logger.LogInformation("GetAllContactMessage Initiated");
            var dtos = await _mediator.Send(new GetAllMessagesListCommand());
            _logger.LogInformation("GetAllSates Completed");
            return Ok(dtos);
        }
        [HttpPost(Name = "AddForm")]
        public async Task<ActionResult> CreateForm([FromBody] CreateFormCommand model)
        {
            try
            {
                _logger.LogInformation("form Initiated");
                var data = await _mediator.Send(model);
                _logger.LogInformation("AddForm Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet(Name = "GetContactById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetContactById(int Id)
        {
            try
            {
                GetContactUsByIdQuery getContactUsByIdQuery = new GetContactUsByIdQuery()
                {
                    Id = Id
                };
                _logger.LogInformation("GetById Initiated");
                var dtos = await _mediator.Send(getContactUsByIdQuery);
                _logger.LogInformation("GetById Completed");
                return Ok(dtos);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut(Name = "UpdateForm")]
        public async Task<ActionResult> Update([FromBody] UpdateContactUsCommand updateFormCommand)
        {


            _logger.LogInformation("Updating Form Initiated");

            var response = await _mediator.Send(updateFormCommand);
            _logger.LogInformation("Updating Form Initiated");

            return Ok(response);
        }

    }
}

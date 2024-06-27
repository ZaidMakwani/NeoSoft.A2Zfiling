using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Register.Command;
using LoginCommand = NeoSoft.A2Zfiling.Application.Features.Login.Command.LoginCommand;
using NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries;
using NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Commands;
using NeoSoft.A2Zfiling.Application.Features.UserInfo.Queries;

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
            catch(Exception ex)
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
            var response = await _mediator.Send(new GetUsersDetailQuery() { UserId = UserId});

            _logger.LogInformation("Login Completed");
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> UpdatePasswordApi(string UserId,string confirmPassword)
        {

            _logger.LogInformation("Login Initiated");
            var response = await _mediator.Send(new UpdatePasswordApiQuery() { UserId = UserId , ConfirmPassword = confirmPassword});

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


        [HttpGet]
        public async Task<ActionResult> GetUserIdByEmail(string Email)
        {

            _logger.LogInformation("Login Initiated");
            var response = await _mediator.Send(new GetUserIdByEmailQuery() { Email = Email });

            _logger.LogInformation("Login Completed");
            return Ok(response);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Login.Command;
using NeoSoft.A2Zfiling.Application.Features.Register.Command;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
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
        [HttpPost(Name = "RegisterAsync")]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterCommand registerCommand)
        {
            _logger.LogInformation("Register Member Initiated");
            var response = await _mediator.Send(registerCommand);
            _logger.LogInformation("Register Member Completed");
            return Ok(response);

        }
        [HttpPost(Name = "Login")]
        public async Task<ActionResult> Login([FromBody] LoginCommand loginCommand)
        {

            _logger.LogInformation("Login Initiated");
            var response = await _mediator.Send(loginCommand);
            _logger.LogInformation("Login Completed");
            return Ok(response);
        }
    }
}

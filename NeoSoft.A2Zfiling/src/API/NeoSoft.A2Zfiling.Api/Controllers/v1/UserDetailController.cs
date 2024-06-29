using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.UpdateStatus;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.DeleteSubStatus;
using NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.CreateUserDetails;
using NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.DeleteUserDetails;
using NeoSoft.A2Zfiling.Application.Features.Userdetails.Command.UpdateUserDetails;
using NeoSoft.A2Zfiling.Application.Features.Userdetails.Queries.GetUserDetailsById;
using NeoSoft.A2Zfiling.Application.Features.Userdetails.Queries.GetUserDetailsList;
using NeoSoft.A2Zfiling.Domain.Entities;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserDetailController> _logger;

        public UserDetailController(IMediator mediator, ILogger<UserDetailController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllUserDetails")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Get All User Document  Action Initiated");

                var data = await _mediator.Send(new GetUserDetailsListQuery());
                _logger.LogInformation("Get All User Document  Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while getting document");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("id", Name = "GetUserDetailById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("GetById Action Initiated");

                var data = await _mediator.Send(new GetUserDetailByIdQuery() { UserDetailId = id });
                _logger.LogInformation("GetById Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost(Name = "AddUserDetail")]
        public async Task<ActionResult> Create([FromForm] CreateUserDetailsCommand model)
        {
            try
            {
                _logger.LogInformation("Create User Detail Action Initiated");

                var data = await _mediator.Send(model);
                _logger.LogInformation("Create User Detail Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while creating user detail");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("id", Name = "UpdateUserDetail")]
        public async Task<ActionResult> Edit([FromForm] UpdateUserDetailsCommand model)
        {
            try
            {
                _logger.LogInformation("Edit User Detail Action Initiated");



                UpdateUserDetailsCommand updatePermissionCommand = new UpdateUserDetailsCommand { };
                var data = await _mediator.Send(model);

                _logger.LogInformation("Edit User Detail Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("id", Name = "DeleteUserDetail")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DeleteUserDetail Action Initiated");

                DeleteUserDetailsCommand deleteUserDetailCommand = new DeleteUserDetailsCommand { UserDetailId=id};
                var data = await _mediator.Send(deleteUserDetailCommand);


                _logger.LogInformation("DeleteUserDetail Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}

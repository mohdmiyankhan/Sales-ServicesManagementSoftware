using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSMS.Application.Commands;
using SSMS.Application.Queries;
using SSMS.Core.Entities;

namespace SSMS.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController(ISender sender) : ControllerBase
    {
        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await sender.Send(new GetAllUsersQuery());
            return StatusCode(result.Status, result);
        }

        [HttpGet("getUserById/{userId}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int userId)
        {
            var result = await sender.Send(new GetUserByIdQuery(userId));
            return StatusCode(result.Status, result);
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserEntity entity)
        {
            var result = await sender.Send(new AddUserCommand(entity));
            return StatusCode(result.Status, result);
        }

        [HttpPut("updateUser/{userId}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] int userId, [FromBody] UserEntity entity)
        {
            var result = await sender.Send(new UpdateUserCommand(userId, entity));
            return StatusCode(result.Status, result);
        }

        [HttpDelete("deleteUser/{userId}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int userId)
        {
            var result = await sender.Send(new DeleteUserCommand(userId));
            return StatusCode(result.Status, result);
        }
    }
}

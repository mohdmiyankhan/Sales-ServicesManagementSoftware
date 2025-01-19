using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSMS.Application.Commands;
using SSMS.Application.Queries;
using SSMS.Core.Entities;

namespace SSMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ISender sender) : ControllerBase
    {
        [HttpPost("addUser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserEntity user)
        {
            var result = await sender.Send(new AddUserCommand(user));
            return Ok(result);
        }

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await sender.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("getUserById/{userId}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid userId)
        {
            var result = await sender.Send(new GetUserByIdQuery(userId));
            return Ok(result);
        }

        [HttpPut("updateUser/{userId}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid userId, [FromBody] UserEntity user)
        {
            var result = await sender.Send(new UpdateUserCommand(userId, user));
            return Ok(result);
        }

        [HttpDelete("deleteUser/{userId}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid userId)
        {
            var result = await sender.Send(new DeleteUserCommand(userId));
            return Ok(result);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSMS.Application.Commands;
using SSMS.Application.Queries;
using SSMS.Core.Entities;

namespace SSMS.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/role")]
    public class RoleController(ISender sender) : ControllerBase
    {
        [HttpGet("getAllRoles")]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var result = await sender.Send(new GetAllRolesQuery());
            return StatusCode(result.Status, result);
        }

        [HttpGet("getRoleById/{roleId}")]
        public async Task<IActionResult> GetRoleByIdAsync([FromRoute] int roleId)
        {
            var result = await sender.Send(new GetRoleByIdQuery(roleId));
            return StatusCode(result.Status, result);
        }

        [HttpPost("addRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] RoleEntity entity)
        {
            var result = await sender.Send(new AddRoleCommand(entity));
            return StatusCode(result.Status, result);
        }

        [HttpPut("updateRole/{roleId}")]
        public async Task<IActionResult> UpdateRoleAsync([FromRoute] int roleId, [FromBody] RoleEntity entity)
        {
            var result = await sender.Send(new UpdateRoleCommand(roleId, entity));
            return StatusCode(result.Status, result);
        }

        [HttpDelete("deleteRole/{roleId}")]
        public async Task<IActionResult> DeleteRoleAsync([FromRoute] int roleId)
        {
            var result = await sender.Send(new DeleteRoleCommand(roleId));
            return StatusCode(result.Status, result);
        }
    }
}

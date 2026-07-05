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
    [Route("api/status")]
    public class StatusController(ISender sender) : ControllerBase
    {
        [HttpGet("getAllStatuses")]
        public async Task<IActionResult> GetAllStatusesAsync()
        {
            var result = await sender.Send(new GetAllStatusesQuery());
            return StatusCode(result.Status, result);
        }

        [HttpGet("getStatusById/{statusId}")]
        public async Task<IActionResult> GetStatusByIdAsync([FromRoute] int statusId)
        {
            var result = await sender.Send(new GetStatusByIdQuery(statusId));
            return StatusCode(result.Status, result);
        }

        [HttpPost("addStatus")]
        public async Task<IActionResult> AddStatusAsync([FromBody] StatusEntity entity)
        {
            var result = await sender.Send(new AddStatusCommand(entity));
            return StatusCode(result.Status, result);
        }

        [HttpPut("updateStatus/{statusId}")]
        public async Task<IActionResult> UpdateRoleAsync([FromRoute] int statusId, [FromBody] StatusEntity entity)
        {
            var result = await sender.Send(new UpdateStatusCommand(statusId, entity));
            return StatusCode(result.Status, result);
        }

        [HttpDelete("deleteStatus/{statusId}")]
        public async Task<IActionResult> DeleteStatusAsync([FromRoute] int statusId)
        {
            var result = await sender.Send(new DeleteStatusCommand(statusId));
            return StatusCode(result.Status, result);
        }
    }
}

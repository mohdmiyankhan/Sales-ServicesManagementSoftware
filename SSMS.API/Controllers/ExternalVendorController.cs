using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSMS.Application.Queries;

namespace SSMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalVendorController(ISender sender) : ControllerBase
    {
        [HttpGet("getCoindeskData")]
        public async Task<IActionResult> GetCoindeskDataAsync()
        {
            var result = await sender.Send(new GetCoindeskDataQuery());
            return Ok(result);
        }

        [HttpGet("getJoke")]
        public async Task<IActionResult> GetJokeAsync()
        {
            var result = await sender.Send(new GetJokeQuery());
            return Ok(result);
        }
    }
}

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
    [Route("api/city")]
    public class CityController(ISender sender) : ControllerBase
    {
        [HttpGet("getAllCities")]
        public async Task<IActionResult> GetAllCitiesAsync()
        {
            var result = await sender.Send(new GetAllCitiesQuery());
            return StatusCode(result.Status, result);
        }

        [HttpGet("getCityById/{cityId}")]
        public async Task<IActionResult> GetCityByIdAsync([FromRoute] int cityId)
        {
            var result = await sender.Send(new GetCityByIdQuery(cityId));
            return StatusCode(result.Status, result);
        }

        [HttpPost("addCity")]
        public async Task<IActionResult> AddCityAsync([FromBody] CityEntity entity)
        {
            var result = await sender.Send(new AddCityCommand(entity));
            return StatusCode(result.Status, result);
        }

        [HttpPut("updateCity/{cityId}")]
        public async Task<IActionResult> UpdateCityAsync([FromRoute] int cityId, [FromBody] CityEntity entity)
        {
            var result = await sender.Send(new UpdateCityCommand(cityId, entity));
            return StatusCode(result.Status, result);
        }

        [HttpDelete("deleteCity/{cityId}")]
        public async Task<IActionResult> DeleteCityAsync([FromRoute] int cityId)
        {
            var result = await sender.Send(new DeleteCityCommand(cityId));
            return StatusCode(result.Status, result);
        }
    }
}

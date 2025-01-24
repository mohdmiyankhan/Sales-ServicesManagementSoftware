using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSMS.Application.Commands;
using SSMS.Application.Queries;
using SSMS.Core.Entities;

namespace SSMS.API.Controllers
{
    [Route("api/country")]
    [ApiController]
    //[Authorize]
    public class CountryController(ISender sender) : ControllerBase
    {
        [HttpGet("getAllCountries")]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var result = await sender.Send(new GetAllCountriesQuery());
            return StatusCode(result.Status, result);
        }

        [HttpGet("getCountryById/{countryId}")]
        public async Task<IActionResult> GetCountryByIdAsync([FromRoute] int countryId)
        {
            var result = await sender.Send(new GetCountryByIdQuery(countryId));
            return StatusCode(result.Status, result);
        }

        [HttpPost("addCountry")]
        public async Task<IActionResult> AddCountryAsync([FromBody] CountryEntity entity)
        {
            var result = await sender.Send(new AddCountryCommand(entity));
            return StatusCode(result.Status, result);
        }

        [HttpPut("updateCountry/{countryId}")]
        public async Task<IActionResult> UpdateCountryAsync([FromRoute] int countryId, [FromBody] CountryEntity entity)
        {
            var result = await sender.Send(new UpdateCountryCommand(countryId, entity));
            return StatusCode(result.Status, result);
        }

        [HttpDelete("deleteCountry/{countryId}")]
        public async Task<IActionResult> DeleteCountryAsync([FromRoute] int countryId)
        {
            var result = await sender.Send(new DeleteCountryCommand(countryId));
            return StatusCode(result.Status, result);
        }
    }
}

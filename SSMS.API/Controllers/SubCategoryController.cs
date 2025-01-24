using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSMS.Application.Commands;
using SSMS.Application.Queries;
using SSMS.Core.Entities;
using SSMS.Core.Models;

namespace SSMS.API.Controllers
{
    [Route("api/subCategory")]
    [ApiController]
    //[Authorize]
    public class SubCategoryController(ISender sender) : ControllerBase
    {
        [HttpGet("getAllSubCategories")]
        public async Task<IActionResult> GetAllSubCategoriesAsync()
        {
            var result = await sender.Send(new GetAllSubCategoriesQuery());
            return StatusCode(result.Status, result);
        }

        [HttpGet("getSubCategoryById/{subCategoryId}")]
        public async Task<IActionResult> GetSubCategoryByIdAsync([FromRoute] int subCategoryId)
        {
            var result = await sender.Send(new GetSubCategoryByIdQuery(subCategoryId));
            return StatusCode(result.Status, result);
        }

        [HttpPost("addSubCategory")]
        public async Task<IActionResult> AddSubCategoryAsync([FromBody] SubCategoryEntity entity)
        {
            var result = await sender.Send(new AddSubCategoryCommand(entity));
            return StatusCode(result.Status, result);
        }

        [HttpPut("updateSubCategory/{subCategoryId}")]
        public async Task<IActionResult> UpdateSubCategoryAsync([FromRoute] int subCategoryId, [FromBody] SubCategoryEntity entity)
        {
            var result = await sender.Send(new UpdateSubCategoryCommand(subCategoryId, entity));
            return StatusCode(result.Status, result);
        }

        [HttpDelete("deleteSubCategory/{subCategoryId}")]
        public async Task<IActionResult> DeleteSubCategoryAsync([FromRoute] int subCategoryId)
        {
            var result = await sender.Send(new DeleteSubCategoryCommand(subCategoryId));
            return StatusCode(result.Status, result);
        }
    }
}

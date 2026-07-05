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
    [Authorize]
    [ApiController]
    [Route("api/category")]
    public class CategoryController(ISender sender) : ControllerBase
    {
        [HttpGet("getAllCategories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var result = await sender.Send(new GetAllCategoriesQuery());
            return StatusCode(result.Status, result);
        }

        [HttpGet("getCategoryById/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int categoryId)
        {
            var result = await sender.Send(new GetCategoryByIdQuery(categoryId));
            return StatusCode(result.Status, result);
        }

        [HttpPost("addCategory")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryEntity entity)
        {
            var result = await sender.Send(new AddCategoryCommand(entity));
            return StatusCode(result.Status, result);
        }

        [HttpPut("updateCategory/{categoryId}")]
        public async Task<IActionResult> UpdateCategoryAsync([FromRoute] int categoryId, [FromBody] CategoryEntity entity)
        {
            var result = await sender.Send(new UpdateCategoryCommand(categoryId, entity));
            return StatusCode(result.Status, result);
        }

        [HttpDelete("deleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int categoryId)
        {
            var result = await sender.Send(new DeleteCategoryCommand(categoryId));
            return StatusCode(result.Status, result);
        }
    }
}

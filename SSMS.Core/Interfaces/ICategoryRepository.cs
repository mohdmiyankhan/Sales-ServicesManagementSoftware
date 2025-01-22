using SSMS.Core.Entities;
using SSMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ApiResponseModel<IEnumerable<CategoryEntity>>> GetAllCategoriesAsync();
        Task<ApiResponseModel<CategoryEntity>> GetCategoryByIdAsync(int categoryId);
        Task<ApiResponseModel<CategoryEntity>> AddCategoryAsync(CategoryEntity entity);
        Task<ApiResponseModel<CategoryEntity>> UpdateCategoryAsync(int categoryId, CategoryEntity entity);
        Task<ApiResponseModel<CategoryEntity>> DeleteCategoryAsync(int categoryId);
    }
}

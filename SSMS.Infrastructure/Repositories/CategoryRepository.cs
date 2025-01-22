using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using SSMS.Infrastructure.Data;

namespace SSMS.Infrastructure.Repositories
{
    public class CategoryRepository(SSMSDbContext dbContext) : ICategoryRepository
    {
        public async Task<ApiResponseModel<IEnumerable<CategoryEntity>>> GetAllCategoriesAsync()
        {
            var categories = await dbContext.CategoryMaster.Where(x => x.IsActive == 1).ToListAsync();
            if (categories.Count > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<CategoryEntity>>
                {
                    Message = "Category list fetched successfully.",
                    Status = 200,
                    Data = categories
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<CategoryEntity>>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CategoryEntity>> GetCategoryByIdAsync(int categoryId)
        {
            var category = await dbContext.CategoryMaster.FirstOrDefaultAsync(x => x.Id == categoryId);
            if (category is not null)
            {
                // Create Api response
                var response = new ApiResponseModel<CategoryEntity>
                {
                    Message = "Category fetched successfully.",
                    Status = 200,
                    Data = category
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CategoryEntity>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CategoryEntity>> AddCategoryAsync(CategoryEntity entity)
        {
            //entity.Id = Guid.NewGuid();
            entity.CreatedBy = null;
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedBy = null;
            entity.ModifiedDate = null;
            entity.DeletedBy = null;
            entity.DeletedDate = null;
            entity.IsActive = 1;

            dbContext.CategoryMaster.Add(entity);
            int res = await dbContext.SaveChangesAsync();
            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CategoryEntity>
                {
                    Message = "Category added successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CategoryEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CategoryEntity>> UpdateCategoryAsync(int categoryId, CategoryEntity entity)
        {
            int res = 0;
            var category = await dbContext.CategoryMaster.FirstOrDefaultAsync(x => x.Id == categoryId);
            if (category is not null)
            {
                category.Category = entity.Category;
                category.Description = entity.Description;
                category.ModifiedBy = null;
                category.ModifiedDate = DateTime.UtcNow;

                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CategoryEntity>
                {
                    Message = "Category updated successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CategoryEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CategoryEntity>> DeleteCategoryAsync(int categoryId)
        {
            int res = 0;
            var category = await dbContext.CategoryMaster.FirstOrDefaultAsync(x => x.Id == categoryId);
            if (category is not null)
            {
                category.DeletedBy = null;
                category.DeletedDate = DateTime.UtcNow;
                category.IsActive = 0;

                //dbContext.CategoryMaster.Remove(category);
                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CategoryEntity>
                {
                    Message = "Category deleted successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CategoryEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using SSMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Infrastructure.Repositories
{
    public class SubCategoryRepository(SSMSDbContext dbContext) : ISubCategoryRepository
    {
        public async Task<ApiResponseModel<IEnumerable<SubCategoryEntity>>> GetAllSubCategoriesAsync()
        {
            var subCategories = await dbContext.SubCategoryMaster.Where(x => x.IsActive == 1).ToListAsync();
            if (subCategories.Count > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<SubCategoryEntity>>
                {
                    Message = "Sub-Category list fetched successfully.",
                    Status = 200,
                    Data = subCategories
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<SubCategoryEntity>>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<SubCategoryEntity>> GetSubCategoryByIdAsync(int subCategoryId)
        {
            var subCategory = await dbContext.SubCategoryMaster.FirstOrDefaultAsync(x => x.Id == subCategoryId);
            if (subCategory is not null)
            {
                // Create Api response
                var response = new ApiResponseModel<SubCategoryEntity>
                {
                    Message = "Sub-Category fetched successfully.",
                    Status = 200,
                    Data = subCategory
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<SubCategoryEntity>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<SubCategoryEntity>> AddSubCategoryAsync(SubCategoryEntity entity)
        {
            //entity.Id = Guid.NewGuid();
            entity.CreatedBy = null;
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedBy = null;
            entity.ModifiedDate = null;
            entity.DeletedBy = null;
            entity.DeletedDate = null;
            entity.IsActive = 1;

            dbContext.SubCategoryMaster.Add(entity);
            int res = await dbContext.SaveChangesAsync();
            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<SubCategoryEntity>
                {
                    Message = "Sub-Category added successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<SubCategoryEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<SubCategoryEntity>> UpdateSubCategoryAsync(int subCategoryId, SubCategoryEntity entity)
        {
            int res = 0;
            var subCategory = await dbContext.SubCategoryMaster.FirstOrDefaultAsync(x => x.Id == subCategoryId);
            if (subCategory is not null)
            {
                subCategory.SubCategory = entity.SubCategory;
                subCategory.CategoryId = entity.CategoryId;
                subCategory.Description = entity.Description;
                subCategory.ModifiedBy = null;
                subCategory.ModifiedDate = DateTime.UtcNow;

                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<SubCategoryEntity>
                {
                    Message = "Sub-Category updated successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<SubCategoryEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<SubCategoryEntity>> DeleteSubCategoryAsync(int subCategoryId)
        {
            int res = 0;
            var subCategory = await dbContext.SubCategoryMaster.FirstOrDefaultAsync(x => x.Id == subCategoryId);
            if (subCategory is not null)
            {
                subCategory.DeletedBy = null;
                subCategory.DeletedDate = DateTime.UtcNow;
                subCategory.IsActive = 0;

                //dbContext.SubCategoryMaster.Remove(subCategory);
                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<SubCategoryEntity>
                {
                    Message = "Sub-Category deleted successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<SubCategoryEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }
    }
}

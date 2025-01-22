using SSMS.Core.Entities;
using SSMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Core.Interfaces
{
    public interface ISubCategoryRepository
    {
        Task<ApiResponseModel<IEnumerable<SubCategoryEntity>>> GetAllSubCategoriesAsync();
        Task<ApiResponseModel<SubCategoryEntity>> GetSubCategoryByIdAsync(int subCategoryId);
        Task<ApiResponseModel<SubCategoryEntity>> AddSubCategoryAsync(SubCategoryEntity entity);
        Task<ApiResponseModel<SubCategoryEntity>> UpdateSubCategoryAsync(int subCategoryId, SubCategoryEntity entity);
        Task<ApiResponseModel<SubCategoryEntity>> DeleteSubCategoryAsync(int subCategoryId);
    }
}

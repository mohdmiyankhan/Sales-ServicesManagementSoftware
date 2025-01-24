using SSMS.Core.Entities;
using SSMS.Core.Models;

namespace SSMS.Core.Interfaces
{
    public interface IStatusRepository
    {
        Task<ApiResponseModel<IEnumerable<StatusEntity>>> GetAllStatusesAsync();
        Task<ApiResponseModel<StatusEntity>> GetStatusByIdAsync(int statusId);
        Task<ApiResponseModel<StatusEntity>> AddStatusAsync(StatusEntity entity);
        Task<ApiResponseModel<StatusEntity>> UpdateStatusAsync(int statusId, StatusEntity entity);
        Task<ApiResponseModel<StatusEntity>> DeleteStatusAsync(int statusId);
    }
}
using SSMS.Core.Entities;
using SSMS.Core.Models;

namespace SSMS.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<ApiResponseModel<IEnumerable<UserEntity>>> GetAllUsersAsync();
        Task<ApiResponseModel<UserEntity>> GetUserByIdAsync(int userId);
        Task<ApiResponseModel<UserEntity>> AddUserAsync(UserEntity entity);
        Task<ApiResponseModel<UserEntity>> UpdateUserAsync(int userId, UserEntity entity);
        Task<ApiResponseModel<UserEntity>> DeleteUserAsync(int userId);
    }
}

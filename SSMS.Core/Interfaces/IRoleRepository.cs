using SSMS.Core.Entities;
using SSMS.Core.Models;

namespace SSMS.Core.Interfaces
{
    public interface IRoleRepository
    {
        Task<ApiResponseModel<IEnumerable<RoleEntity>>> GetAllRolesAsync();
        Task<ApiResponseModel<RoleEntity>> GetRoleByIdAsync(int roleId);
        Task<ApiResponseModel<RoleEntity>> AddRoleAsync(RoleEntity entity);
        Task<ApiResponseModel<RoleEntity>> UpdateRoleAsync(int roleId, RoleEntity entity);
        Task<ApiResponseModel<RoleEntity>> DeleteRoleAsync(int roleId);
    }
}
using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using SSMS.Infrastructure.Data;

namespace SSMS.Infrastructure.Repositories
{
    public class RoleRepository(SSMSDbContext dbContext) : IRoleRepository
    {
        public async Task<ApiResponseModel<IEnumerable<RoleEntity>>> GetAllRolesAsync()
        {
            var roles = await dbContext.RoleMaster.ToListAsync();
            if (roles.Count > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<RoleEntity>>
                {
                    Message = "Role list fetched successfully.",
                    Status = 200,
                    Data = roles
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<RoleEntity>>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<RoleEntity>> GetRoleByIdAsync(int roleId)
        {
            var role = await dbContext.RoleMaster.FirstOrDefaultAsync(x => x.Id == roleId);
            if (role is not null)
            {
                // Create Api response
                var response = new ApiResponseModel<RoleEntity>
                {
                    Message = "Role fetched successfully.",
                    Status = 200,
                    Data = role
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<RoleEntity>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<RoleEntity>> AddRoleAsync(RoleEntity entity)
        {
            //entity.Id = Guid.NewGuid();
            entity.CreatedBy = null;
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedBy = null;
            entity.ModifiedDate = null;
            entity.DeletedBy = null;
            entity.DeletedDate = null;
            entity.IsActive = 1;

            dbContext.RoleMaster.Add(entity);
            int res = await dbContext.SaveChangesAsync();
            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<RoleEntity>
                {
                    Message = "Role added successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<RoleEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<RoleEntity>> UpdateRoleAsync(int roleId, RoleEntity entity)
        {
            int res = 0;
            var role = await dbContext.RoleMaster.FirstOrDefaultAsync(x => x.Id == roleId);
            if (role is not null)
            {
                role.Role = entity.Role;
                role.ModifiedBy = null;
                role.ModifiedDate = DateTime.UtcNow;

                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<RoleEntity>
                {
                    Message = "Role updated successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<RoleEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<RoleEntity>> DeleteRoleAsync(int roleId)
        {
            int res = 0;
            var role = await dbContext.RoleMaster.FirstOrDefaultAsync(x => x.Id == roleId);
            if (role is not null)
            {
                role.DeletedBy = null;
                role.DeletedDate = DateTime.UtcNow;
                role.IsActive = 0;

                //dbContext.RoleMaster.Remove(role);
                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<RoleEntity>
                {
                    Message = "Role deleted successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<RoleEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }
    }
}

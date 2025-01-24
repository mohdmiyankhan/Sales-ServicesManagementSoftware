using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using SSMS.Infrastructure.Data;
using System.Data;

namespace SSMS.Infrastructure.Repositories
{
    public class UserRepository(SSMSDbContext dbContext) : IUserRepository
    {
        public async Task<ApiResponseModel<IEnumerable<UserEntity>>> GetAllUsersAsync()
        {
            IQueryable<UserEntity> usersQ = dbContext.UserMaster;
            IEnumerable<UserEntity> usersE = await usersQ.Where(x => x.IsActive == 1).ToListAsync();

            if (usersE.Any())
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<UserEntity>>
                {
                    Message = "User list fetched successfully.",
                    Status = 200,
                    Data = usersE
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<UserEntity>>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<UserEntity>> GetUserByIdAsync(int userId)
        {
            var user = await dbContext.UserMaster.FirstOrDefaultAsync(x => x.Id == userId);
            if (user is not null)
            {
                // Create Api response
                var response = new ApiResponseModel<UserEntity>
                {
                    Message = "User fetched successfully.",
                    Status = 200,
                    Data = user
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<UserEntity>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<UserEntity>> AddUserAsync(UserEntity entity)
        {
            //entity.Id = Guid.NewGuid();
            entity.CreatedBy = null;
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedBy = null;
            entity.ModifiedDate = null;
            entity.DeletedBy = null;
            entity.DeletedDate = null;
            entity.IsActive = 1;

            dbContext.UserMaster.Add(entity);
            int res = await dbContext.SaveChangesAsync();
            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<UserEntity>
                {
                    Message = "User added successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<UserEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<UserEntity>> UpdateUserAsync(int userId, UserEntity entity)
        {
            int res = 0;
            var user = await dbContext.UserMaster.FirstOrDefaultAsync(x => x.Id == userId);
            if (user is not null)
            {
                user.Name = entity.Name;
                user.MobileNo = entity.MobileNo;
                user.EmailId = entity.EmailId;
                user.RoleId = entity.RoleId;

                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<UserEntity>
                {
                    Message = "User updated successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<UserEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<UserEntity>> DeleteUserAsync(int userId)
        {
            int res = 0;
            var user = await dbContext.UserMaster.FirstOrDefaultAsync(x => x.Id == userId);
            if (user is not null)
            {
                user.DeletedBy = null;
                user.DeletedDate = DateTime.UtcNow;
                user.IsActive = 0;

                //dbContext.UserMaster.Remove(user);
                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<UserEntity>
                {
                    Message = "User deleted successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<UserEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }
    }
}

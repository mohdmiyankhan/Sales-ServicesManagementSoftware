using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using SSMS.Infrastructure.Data;

namespace SSMS.Infrastructure.Repositories
{
    public class StatusRepository(SSMSDbContext dbContext) : IStatusRepository
    {
        public async Task<ApiResponseModel<IEnumerable<StatusEntity>>> GetAllStatusesAsync()
        {
            IQueryable<StatusEntity> statusesQ = dbContext.StatusMaster;
            IEnumerable<StatusEntity> statusesE = await statusesQ.Where(x => x.IsActive == 1).ToListAsync();

            if (statusesE.Any())
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<StatusEntity>>
                {
                    Message = "Status list fetched successfully.",
                    Status = 200,
                    Data = statusesE
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<StatusEntity>>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<StatusEntity>> GetStatusByIdAsync(int statusId)
        {
            var status = await dbContext.StatusMaster.FirstOrDefaultAsync(x => x.Id == statusId);
            if (status is not null)
            {
                // Create Api response
                var response = new ApiResponseModel<StatusEntity>
                {
                    Message = "Status fetched successfully.",
                    Status = 200,
                    Data = status
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<StatusEntity>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<StatusEntity>> AddStatusAsync(StatusEntity entity)
        {
            //entity.Id = Guid.NewGuid();
            entity.CreatedBy = null;
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedBy = null;
            entity.ModifiedDate = null;
            entity.DeletedBy = null;
            entity.DeletedDate = null;
            entity.IsActive = 1;

            dbContext.StatusMaster.Add(entity);
            int res = await dbContext.SaveChangesAsync();
            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<StatusEntity>
                {
                    Message = "Status added successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<StatusEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<StatusEntity>> UpdateStatusAsync(int statusId, StatusEntity entity)
        {
            int res = 0;
            var status = await dbContext.StatusMaster.FirstOrDefaultAsync(x => x.Id == statusId);
            if (status is not null)
            {
                status.Status = entity.Status;
                status.ModifiedBy = null;
                status.ModifiedDate = DateTime.UtcNow;

                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<StatusEntity>
                {
                    Message = "Status updated successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<StatusEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<StatusEntity>> DeleteStatusAsync(int statusId)
        {
            int res = 0;
            var status = await dbContext.StatusMaster.FirstOrDefaultAsync(x => x.Id == statusId);
            if (status is not null)
            {
                status.DeletedBy = null;
                status.DeletedDate = DateTime.UtcNow;
                status.IsActive = 0;

                //dbContext.StatusMaster.Remove(status);
                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<StatusEntity>
                {
                    Message = "Status deleted successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<StatusEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }
    }
}

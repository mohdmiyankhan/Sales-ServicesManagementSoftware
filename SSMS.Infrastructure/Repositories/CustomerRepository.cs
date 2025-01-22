using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using SSMS.Infrastructure.Data;

namespace SSMS.Infrastructure.Repositories
{
    public class CustomerRepository(SSMSDbContext dbContext) : ICustomerRepository
    {
        public async Task<ApiResponseModel<IEnumerable<CustomerEntity>>> GetAllCustomersAsync()
        {
            var customers = await dbContext.CustomerMaster.ToListAsync();
            if (customers.Count > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<CustomerEntity>>
                {
                    Message = "Customer list fetched successfully.",
                    Status = 200,
                    Data = customers
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<CustomerEntity>>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CustomerEntity>> GetCustomerByIdAsync(int customerId)
        {
            var customer = await dbContext.CustomerMaster.FirstOrDefaultAsync(x => x.Id == customerId);
            if (customer is not null)
            {
                // Create Api response
                var response = new ApiResponseModel<CustomerEntity>
                {
                    Message = "Customer fetched successfully.",
                    Status = 200,
                    Data = customer
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CustomerEntity>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CustomerEntity>> AddCustomerAsync(CustomerEntity entity)
        {
            //entity.Id = Guid.NewGuid();
            entity.CreatedBy = null;
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedBy = null;
            entity.ModifiedDate = null;
            entity.DeletedBy = null;
            entity.DeletedDate = null;
            entity.IsActive = 1;

            dbContext.CustomerMaster.Add(entity);
            int res = await dbContext.SaveChangesAsync();
            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CustomerEntity>
                {
                    Message = "Customer added successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CustomerEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CustomerEntity>> UpdateCustomerAsync(int customerId, CustomerEntity entity)
        {
            int res = 0;
            var customer = await dbContext.CustomerMaster.FirstOrDefaultAsync(x => x.Id == customerId);

            if (customer is not null)
            {
                customer.CustomerName = entity.CustomerName;
                customer.MobileNo = entity.MobileNo;
                customer.AltMobileNo = entity.AltMobileNo;
                customer.EmailId = entity.EmailId;
                customer.Address = entity.Address;
                customer.ModifiedBy = null;
                customer.ModifiedDate = DateTime.UtcNow;

                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CustomerEntity>
                {
                    Message = "Customer updated successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CustomerEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CustomerEntity>> DeleteCustomerAsync(int customerId)
        {
            int res = 0;
            var customer = await dbContext.CustomerMaster.FirstOrDefaultAsync(x => x.Id == customerId);

            if (customer is not null)
            {
                customer.DeletedBy = null;
                customer.DeletedDate = DateTime.UtcNow;
                customer.IsActive = 0;

                //dbContext.CustomerMaster.Remove(customer);
                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CustomerEntity>
                {
                    Message = "Customer deleted successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CustomerEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }
    }
}

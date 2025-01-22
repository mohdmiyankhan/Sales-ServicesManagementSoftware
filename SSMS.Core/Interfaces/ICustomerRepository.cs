using SSMS.Core.Entities;
using SSMS.Core.Models;

namespace SSMS.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<ApiResponseModel<IEnumerable<CustomerEntity>>> GetAllCustomersAsync();
        Task<ApiResponseModel<CustomerEntity>> GetCustomerByIdAsync(int customerId);
        Task<ApiResponseModel<CustomerEntity>> AddCustomerAsync(CustomerEntity entity);
        Task<ApiResponseModel<CustomerEntity>> UpdateCustomerAsync(int customerId, CustomerEntity entity);
        Task<ApiResponseModel<CustomerEntity>> DeleteCustomerAsync(int customerId);
    }
}

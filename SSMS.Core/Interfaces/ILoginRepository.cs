using SSMS.Core.Entities;
using SSMS.Core.Models;

namespace SSMS.Core.Interfaces
{
    public interface ILoginRepository
    {
        Task<UserEntity> ValidateUser(LoginModel login);
    }
}
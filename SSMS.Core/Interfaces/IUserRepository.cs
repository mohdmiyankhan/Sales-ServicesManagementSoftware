using SSMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetUsersAsync();
        Task<UserEntity> GetUserByIdAsync(Guid id);
        Task<UserEntity> AddUserAsync(UserEntity entity);
        Task<UserEntity> UpdateUserAsync(Guid userId, UserEntity entity);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}

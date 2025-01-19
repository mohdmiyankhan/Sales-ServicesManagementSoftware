using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Infrastructure.Repositories
{
    public class UserRepository(SSMSDbContext dbContext) : IUserRepository
    {
        public async Task<IEnumerable<UserEntity>> GetUsersAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserEntity> AddUserAsync(UserEntity entity)
        {
            entity.Id = Guid.NewGuid();
            dbContext.Users.Add(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<UserEntity> UpdateUserAsync(Guid userId, UserEntity entity)
        {
            var employee = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (employee is not null)
            {
                employee.Name = entity.Name;
                employee.Email = entity.Email;
                employee.Phone = entity.Phone;

                await dbContext.SaveChangesAsync();

                return employee;
            }

            return entity;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var employee = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (employee is not null)
            {
                dbContext.Users.Remove(employee);

                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}

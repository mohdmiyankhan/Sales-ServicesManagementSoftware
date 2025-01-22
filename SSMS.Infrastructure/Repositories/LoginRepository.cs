using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using SSMS.Infrastructure.Data;

namespace SSMS.Infrastructure.Repositories
{
    public class LoginRepository(SSMSDbContext dbContext) : ILoginRepository
    {
        public async Task<UserEntity> ValidateUser(LoginModel model)
        {
            var user = await dbContext.UserMaster.FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

            return user;
        }
    }
}

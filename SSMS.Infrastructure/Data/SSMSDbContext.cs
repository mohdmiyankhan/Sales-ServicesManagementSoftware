using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;

namespace SSMS.Infrastructure.Data
{
    public class SSMSDbContext(DbContextOptions<SSMSDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;

namespace SSMS.Infrastructure.Data
{
    public class SSMSDbContext(DbContextOptions<SSMSDbContext> options) : DbContext(options)
    {
        public DbSet<CustomerEntity> CustomerMaster { get; set; }
        public DbSet<CategoryEntity> CategoryMaster { get; set; }
        public DbSet<SubCategoryEntity> SubCategoryMaster { get; set; }
        public DbSet<CountryEntity> CountryMaster { get; set; }
        public DbSet<CityEntity> CityMaster { get; set; }
        public DbSet<RoleEntity> RoleMaster { get; set; }
        public DbSet<StatusEntity> StatusMaster { get; set; }
        public DbSet<UserEntity> UserMaster { get; set; }
    }
}

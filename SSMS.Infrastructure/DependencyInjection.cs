using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Infrastructure.Data;
using SSMS.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<SSMSDbContext>(options =>
            {
                options.UseSqlServer("Server=.; Database=SSMSDB; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=True");
            });

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

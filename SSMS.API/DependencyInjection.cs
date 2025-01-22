using SSMS.Application;
using SSMS.Core;
using SSMS.Infrastructure;

namespace SSMS.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSSMSDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                    .AddCoreDI(configuration)
                    .AddInfrastructureDI();

            return services;
        }
    }
}

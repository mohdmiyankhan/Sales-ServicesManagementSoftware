using SSMS.Application;
using SSMS.Infrastructure;

namespace SSMS.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSSMSDI(this IServiceCollection service)
        {
            service.AddApplicationDI()
                .AddInfrastructureDI();
            return service;
        }
    }
}

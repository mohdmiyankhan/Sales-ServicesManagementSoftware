using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SSMS.Core.Interfaces;
using SSMS.Core.Options;
using SSMS.Infrastructure.Data;
using SSMS.Infrastructure.Repositories;
using SSMS.Infrastructure.Services;

namespace SSMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<SSMSDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.SSMS_ConnectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IExternalVendorRepository, ExternalVendorRepository>();

            services.AddHttpClient<ICoindeskHttpClientService, CoindeskHttpClientService>(options =>
            {
                options.BaseAddress = new Uri("https://api.coindesk.com/v1/");
            });
            
            services.AddHttpClient<IJokeHttpClientService, JokeHttpClientService>(options =>
            {
                options.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
            });

            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCCPOS.Backend.SecurityService.Application.Contract;
using TCCPOS.Backend.SecurityService.Infrastructure.Repository;

namespace TCCPOS.Backend.SecurityService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var mysqlconnstr = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<SecurityContext>(x => x.UseMySql(mysqlconnstr, ServerVersion.AutoDetect(mysqlconnstr)));

            services.AddScoped<ISecurityRepository, SecurityRepository>();
            return services;
        }
    }
}
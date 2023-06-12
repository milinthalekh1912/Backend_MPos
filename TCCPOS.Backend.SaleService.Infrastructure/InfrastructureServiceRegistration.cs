using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCCPOS.Backend.SaleService.Application.Contract;
using TCCPOS.Backend.SaleService.Infrastructure.Repository;

namespace TCCPOS.Backend.SaleService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var mysqlconnstr = configuration.GetConnectionString("ConnectionString");
            //services.AddDbContext<SaleContext>(x => x.UseMySql(mysqlconnstr, ServerVersion.AutoDetect(mysqlconnstr)));

            services.AddScoped<ISaleRepository, SaleRepository>();
            return services;
        }
    }
}
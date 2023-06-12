using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCCPOS.Backend.ReportService.Application.Contract;
using TCCPOS.Backend.ReportService.Infrastructure.Repository;

namespace TCCPOS.Backend.ReportService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        private static string GetAuthorization(IServiceProvider sp)
        {
            var authorization = sp.GetService<IHttpContextAccessor>()?.HttpContext?.Request?.Headers["Authorization"].ToString() ?? "";
            if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)) authorization = authorization.Substring(7);
            return authorization;
        }
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var mysqlconnstr = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<ReportContext>(x => x.UseMySql(mysqlconnstr, ServerVersion.AutoDetect(mysqlconnstr)));

            services.AddScoped<IReportRepository, ReportRepository>();
            
            /*services.AddScoped<ISaleServiceWebApi, SaleServiceWebApi>(x =>
            {
                var baseurl = configuration["BaseUrl:SaleService"] ?? "";
                return new SaleServiceWebApi(baseurl, GetAuthorization(x));
            });

            services.AddScoped<IInventoryServiceWebApi, InventoryServiceWebApi>(x =>
            {
                var baseurl = configuration["BaseUrl:InventoryService"] ?? "";
                return new InventoryServiceWebApi(baseurl, GetAuthorization(x));
            });*/
            return services;
        }

    }
}
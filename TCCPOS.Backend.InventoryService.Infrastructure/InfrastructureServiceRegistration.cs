using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCCPOS.Backend.InventoryService.Application.Contract;
//using TCCPOS.Backend.InventoryService.Infrastructure.Outbound;
using TCCPOS.Backend.InventoryService.Infrastructure.Repository;

namespace TCCPOS.Backend.InventoryService.Infrastructure
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
            services.AddDbContext<InventoryContext>(x => x.UseMySql(mysqlconnstr, ServerVersion.AutoDetect(mysqlconnstr)));

            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<ITargetRepository, TargetRepository>();
            return services;
        }
    }
}
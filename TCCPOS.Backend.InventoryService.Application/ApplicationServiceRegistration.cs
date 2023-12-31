﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TCCPOS.Backend.InventoryService.Application.Behaviours;

namespace TCCPOS.Backend.InventoryService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            return services;
        }
    }
}

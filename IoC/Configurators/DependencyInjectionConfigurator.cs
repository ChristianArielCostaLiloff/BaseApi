﻿using Domain.Services.Services;
using Domain.Services.Services.Interfaces;
using Infraestructure.Core.Database;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interfaces;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Configurators
{
    public class DependencyInjectionConfigurator
    {
        public static void DependencyInjectionConfiguration(IServiceCollection services)
        {
            // Infraestructure
            services.AddScoped<SeedDb>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Domain
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();

            // Cache
            services.AddMemoryCache();
            services.AddScoped<IRolePermissionCacheService, RolePermissionCacheService>();
        }
    }
}

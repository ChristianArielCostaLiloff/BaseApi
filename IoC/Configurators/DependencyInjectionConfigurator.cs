using Domain.Services.Services;
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

            // Common
            services.AddScoped<RolePermissionCacheService>();

            // Cache
            services.AddMemoryCache();
            // Initialize cache during service registration
            //var serviceProvider = services.BuildServiceProvider();
            //var rolePermissionCacheService = serviceProvider.GetRequiredService<RolePermissionCacheService>();
            //rolePermissionCacheService.LoadCache();

        }
    }
}

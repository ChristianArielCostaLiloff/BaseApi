using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IoC.BaseApi.Configurators
{
    public static class JwtAuthConfigurator
    {
        public static void ConfigureJwtAuthentication(IServiceCollection services, IConfigurationSection tokenAppSetting)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie()
                .AddJwtBearer(cfg =>
                {
                    string? keyValue = tokenAppSetting.GetSection("Key").Value ?? throw new ArgumentException("Key is null in appsettings.json");

                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = tokenAppSetting.GetSection("Issuer").Value,
                        ValidAudience = tokenAppSetting.GetSection("Audience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue))
                    };
                });
        }
    }
}

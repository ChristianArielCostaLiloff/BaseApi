using Infraestructure.Core.Database;
using Microsoft.EntityFrameworkCore;
using IoC.Configurators;
using Domain.Services.Services;

var builder = WebApplication.CreateBuilder(args);

#region SQL Server
builder.Services.AddDbContext<ApiDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringSQLServer"));
});
#endregion

#region Injection
DependencyInjectionConfigurator.DependencyInjectionConfiguration(builder.Services);
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region JWT
var tokenAppSetting = builder.Configuration.GetSection("Tokens");
JwtAuthConfigurator.ConfigureJwtAuthentication(builder.Services, tokenAppSetting);
#endregion

var app = builder.Build();

#region SeedDb
IServiceScopeFactory? scopeFactory = app.Services.GetService<IServiceScopeFactory>();
if (scopeFactory != null)
{
    using (IServiceScope scope = scopeFactory.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<SeedDb>();
        seeder!.InitializeDataAsync().Wait();
    }
}
#endregion

#region Load Cache
using (var scope = app.Services.CreateScope())
{
    var rolePermissionCacheService = scope.ServiceProvider.GetRequiredService<RolePermissionCacheService>();
    rolePermissionCacheService.LoadCache();
}
#endregion
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

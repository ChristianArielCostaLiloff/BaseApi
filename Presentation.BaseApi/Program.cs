using Infraestructure.Core.Database;
using Microsoft.EntityFrameworkCore;
using Presentation.BaseApi.Configurator;

var builder = WebApplication.CreateBuilder(args);

#region SQL Server
builder.Services.AddDbContext<BaseApiDbContext>(op =>
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

var app = builder.Build();

#region SeedDb
IServiceScopeFactory? scopeFactory = app.Services.GetService<IServiceScopeFactory>();
using (IServiceScope scope = scopeFactory.CreateScope())
{
    var seeder = scope.ServiceProvider.GetService<SeedDb>();
    seeder!.InitializeDataAsync().Wait();
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

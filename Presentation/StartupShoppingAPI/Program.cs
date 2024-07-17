using StartupShopping.Infrastructure;
using StartupShopping.Infrastructure.Services.Storage.Local;
using StartupShopping.Persistance;
using StartupShopping.Persistance.Middlewares;
using StartupShoppingAPI;
using System.Reflection;
using MediatR;
using StartupShopping.Application;
using StartupShopping.Application.Abstractions.Identity;
using StartupShopping.Infrastructure.Services.Identity;
using StartupShopping.Persistance.Contexts;
using StartupShoppingAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddInfrastructureService();
builder.Services.AddApplicationServices();
//builder.Services.AddStorage(StartupShopping.Infrastructure.Enums.StorageType.Local);
builder.Services.AddStorage<LocalStorage>();
builder.Services.AddCorsExtension();
builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddRoleSeedService();

builder.Services.AddScoped<RoleSeedService>(); // Singleton olarak eklenmesi tercih edilir
//builder.Services.AddJwtAuth(builder.Configuration);
//builder.Services.AddJwtAuthSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var roleSeedService = services.GetRequiredService<RoleSeedService>();
    await roleSeedService.SeedRolesAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Hata: Roller eklenirken bir sorun oluştu. Hata: {ex.Message}");
}

app.UseStaticFiles();
app.UseCors();

app.UseHttpsRedirection();

//app.UseSessionValidation();


app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StartupShopping.Application.Abstractions.Identity;
using StartupShopping.Domain.Entities;
using StartupShopping.Infrastructure.Services.Identity;
using StartupShopping.Infrastructure.Services.Token_Password;
using System.Text;

namespace StartupShoppingAPI
{
    public static class DI
    {
        //private readonly static IRoleManager _roleManager;
        
        public static void AddCorsExtension(this IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("https://localhost:5049/", "https://localhost:5049/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }


     

    }
}

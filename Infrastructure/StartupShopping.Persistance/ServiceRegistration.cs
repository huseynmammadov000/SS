using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StartupShopping.Application.Abstractions.Token_Password;
using StartupShopping.Application.Repositories.AppUserRepository;
using StartupShopping.Application.Repositories.CategoryRepository;
using StartupShopping.Application.Repositories.CompanyRepository;
using StartupShopping.Application.Repositories.PortfolioRepository;
using StartupShopping.Application.Repositories.RadarRepository;
using StartupShopping.Application.Repositories.RefreshTokenRepository;
using StartupShopping.Application.Repositories.SessionRepository;
using StartupShopping.Application.Repositories.StartupRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Domain.Entities.Jwt;
using StartupShopping.Domain.Entities.Models;
using StartupShopping.Persistance.Contexts;
using StartupShopping.Persistance.Middlewares;
using StartupShopping.Persistance.Repositories.AppUserRepository;
using StartupShopping.Persistance.Repositories.CategoryRepository;
using StartupShopping.Persistance.Repositories.CompanyRepository;
using StartupShopping.Persistance.Repositories.PortfolioRepository;
using StartupShopping.Persistance.Repositories.RadarRepository;
using StartupShopping.Persistance.Repositories.RefreshTokenRepository;
using StartupShopping.Persistance.Repositories.SessionRepository;
using StartupShopping.Persistance.Repositories.StartupRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StartupShoppingDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SSConstr")));

            //      // Identity servislerini ekleyin
            //      services.AddScoped<AppUser, Role>(options =>
            //      {
            //          // Identity ayarları burada yapılabilir
            //          options.Password.RequireDigit = true;
            //          options.Password.RequiredLength = 8;
            //          options.Password.RequireNonAlphanumeric = true;
            //          options.User.RequireUniqueEmail = true;
            //      })
            //.AddEntityFrameworkStores<StartupShoppingDbContext>() // DbContext tipinizi buraya ekleyin
            //.AddDefaultTokenProviders();
            //services.AddSingleton<JwtSettings>(configuration.GetSection("JwtSettings").Get<JwtSettings>());
            //services.Configure<CookieConfig>(configuration.GetSection("CookieConfig"));

            //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            //services.AddScoped>();


            //services.AddScoped<IAppUserReadRepository, AppUserReadRepository>();
            //services.AddScoped<IAppUserWriteRepository, AppUserWriteRepository>();

            //services.AddScoped<ICategoryReadRepository,CategoryReadRepository>();
            //services.AddScoped<ICategoryWriteRepository,CategoryWriteRepository>();

            //services.AddScoped<ICompanyReadRepository,CompanyReadRepository>();
            //services.AddScoped<ICompanyWriteRepository,CompanyWriteRepository>();

            //services.AddScoped<IPortfolioReadRepository,PortfolioReadRepository>();
            //services.AddScoped<IPortfolioWriteRepository,PortfolioWriteRepository>();

            //services.AddScoped<IRadarReadRepository, RadarReadRepository>();
            //services.AddScoped<IRadarWriteRepository, RadarWriteRepository>();

            //services.AddScoped<IStartupReadRepository,StartupReadRepository>(); 
            //services.AddScoped<IStartupWriteRepository,StartupWriteRepository>();

            ////services.AddScoped<IRefreshTokenReadRepository, RefreshTokenReadRepository>();
            ////services.AddScoped<IRefreshTokenWriteRepository, RefreshTokenWriteRepository>();

            //services.AddScoped<ISessionReadRepository,SessionReadRepository>();
            //services.AddScoped<ISessionWriteRepository,SessionWriteRepository>();


            //var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

            //var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        RequireExpirationTime = true,
            //        ValidateLifetime = true
            //    };
            //});
            //services.AddControllers();

            //var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});

            //services.AddScoped<ITokenService, TokenService>();
        }
      
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StartupShopping.Application.Abstractions.Auth;
using StartupShopping.Application.Abstractions.Identity;
using StartupShopping.Application.Abstractions.Storage;
using StartupShopping.Application.Abstractions.Token_Password;
using StartupShopping.Application.Services;
using StartupShopping.Domain.Entities;
using StartupShopping.Infrastructure.Enums;
using StartupShopping.Infrastructure.Services;
using StartupShopping.Infrastructure.Services.Auth;
using StartupShopping.Infrastructure.Services.Identity;
using StartupShopping.Infrastructure.Services.Storage;
using StartupShopping.Infrastructure.Services.Storage.Local;
using StartupShopping.Infrastructure.Services.Token_Password;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<IPasswordHasher,PasswordHasher>();
            //serviceCollection.AddScoped<ITokenService, TokenService>();
            serviceCollection.AddScoped<IAuthService,AuthService>();

            //serviceCollection.AddScoped<ISignInManager,SignInManager>();
            serviceCollection.AddScoped<IUserManager,UserManager>();
            serviceCollection.AddScoped<IRoleManager,RoleManager>();

            
        }


        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                //case StorageType.Azure:
                //    serviceCollection.AddScoped<IStorage, AzureStorage>();
                //    break;
                case StorageType.AWS:

                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}

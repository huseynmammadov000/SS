using Microsoft.EntityFrameworkCore;
using StartupShopping.Application.Abstractions.Auth;
using StartupShopping.Application.Abstractions.Identity;
using StartupShopping.Application.Abstractions.Token_Password;
using StartupShopping.Application.DTO_s;
using StartupShopping.Application.Repositories.AppUserRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StartupShopping.Infrastructure.Services.Identity
{
    public class UserManager : IUserManager
    {
        private readonly IAppUserReadRepository _appUserReadRepository;
        private readonly IAppUserWriteRepository _appUserWriteRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly StartupShoppingDbContext _context;

        private readonly IAuthService _authService;

        public UserManager(IAppUserReadRepository appUserReadRepository, IAppUserWriteRepository appUserWriteRepository, IPasswordHasher passwordHasher, IAuthService authService)
        {
            _appUserReadRepository = appUserReadRepository;
            _appUserWriteRepository = appUserWriteRepository;
            _passwordHasher = passwordHasher;
            _authService = authService;
        }

        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            return  await  Task.Run(()=> _passwordHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt));
            
        }

        public async Task<TokenDto> CreateUserAsync(string userName,string email, string password,string passwordConfirm,string roleName)
        {
            //if (password == passwordConfirm)
            //{
               
            //    TokenDto token = await _authService.RegisterAsync(userName,email, password,roleName);

            //    return token;
            //}
            //else throw new InvalidOperationException();
             throw new InvalidOperationException();
           
        }

        public async Task<AppUser> FindByEmailAsync(string email)
        {
            return await _appUserReadRepository.GetByEmailAsync(email);
        }

        public async Task<AppUser> FindByUsernameAsync(string username)
        {
            return await _appUserReadRepository.GetByUserNameAsync(username);
        }
    }
}

using Microsoft.EntityFrameworkCore;
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

namespace StartupShopping.Persistance.Repositories.AppUserRepository
{
    public class AppUserWriteRepository : WriteRepository<AppUser>, IAppUserWriteRepository
    {
        private readonly StartupShoppingDbContext _dbContext;
        readonly IPasswordHasher _passwordHasher;
        //readonly ITokenService _tokenService;
        

        public AppUserWriteRepository(StartupShoppingDbContext dbContext, IPasswordHasher passwordHasher/*, ITokenService tokenService*/) : base(dbContext)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            //_tokenService = tokenService;
        }

        //public async Task<TokenDto> CreateUser(string userName,string email, string password, string roleName)
        //{
        //    _passwordHasher.CreatePasswordHash(password,out byte[] hash,out byte[] salt);

        //    var role = _dbContext.Roles.FirstOrDefault(r => r.Name == roleName);

        //    //var role = new Role()
        //    //{
        //    //    Name = roleName,

        //    //};
        //    var userRole = new AppUserRole
        //    {
               
        //        Role = role,
        //        RoleId = (await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName)).Id,
               
                
        //    };
        //    //user.UserRoles.Add(userRole);

        //    //appUser.UserRoles.Add(userRole);

        //    List<AppUserRole> appUserRoles = new();
        //    appUserRoles.Add(userRole);

        //    var appUser = new AppUser()
        //    {
        //        Id = Guid.NewGuid(),
        //        UserName = userName,
        //        Email = email,
        //        UserRoles = appUserRoles,
        //        PasswordHash = hash,
        //        PasswordSalt = salt,
               
        //    };
        //    var refreshToken = await _tokenService.GenerateRefreshToken(appUser);
        //    appUser.RefreshToken = refreshToken;
        //    appUser.RefreshTokenId = refreshToken.Id;

        //    var accessToken = _tokenService.GenerateToken(appUser);
        //    _dbContext.RefreshTokens.Add(appUser.RefreshToken);
        //    await _dbContext.AddAsync(appUser);
        //    //var refreshToken = _tokenService.GenerateRefreshToken();
        //    await _dbContext.SaveChangesAsync();
           

        //    return new TokenDto
        //    {
        //        AccessToken = accessToken,
        //        RefreshToken = appUser.RefreshToken,
        //        Expiration = DateTime.UtcNow.AddHours(1) 
        //    };


        //}
    }
}

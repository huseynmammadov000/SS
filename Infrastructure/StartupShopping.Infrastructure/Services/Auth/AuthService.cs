using Azure.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StartupShopping.Application.Abstractions.Auth;
using StartupShopping.Application.Abstractions.Token_Password;
using StartupShopping.Application.DTO_s;
using StartupShopping.Application.Repositories.AppUserRepository;
using StartupShopping.Application.Repositories.RefreshTokenRepository;
using StartupShopping.Application.Repositories.SessionRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Domain.Entities.Models;
using StartupShopping.Infrastructure.Services.Token_Password;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StartupShopping.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
      //  private readonly IAppUserReadRepository _appUserReadRepository;
      //  private readonly IAppUserWriteRepository _appUserWriteRepository;

      //  //private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;
      //  //private readonly IRefreshTokenReadRepository _refreshTokenReadRepository;

      //  private readonly ISessionReadRepository _sessionReadRepository;
      //  private readonly ISessionWriteRepository _sessionWriteRepository;

      //  private readonly StartupShoppingDbContext _dbContext;

      //  private readonly IPasswordHasher _passwordHasher;
      //  //private readonly ITokenService _tokenService;

      //  private readonly IConfiguration _configuration;

      //  public AuthService(IPasswordHasher passwordHasher, /*ITokenService tokenService,*/ IAppUserReadRepository appUserReadRepository, IAppUserWriteRepository appUserWriteRepository, StartupShoppingDbContext dbContext, IConfiguration configuration, /*IRefreshTokenWriteRepository refreshTokenWriteRepository, IRefreshTokenReadRepository refreshTokenReadRepository,*/ ISessionReadRepository sessionReadRepository, ISessionWriteRepository sessionWriteRepository)
      //  {

      //      _passwordHasher = passwordHasher;
      //      //_tokenService = tokenService;
      //      _appUserReadRepository = appUserReadRepository;
      //      _appUserWriteRepository = appUserWriteRepository;
      //      _dbContext = dbContext;
      //      _configuration = configuration;
      //      //_refreshTokenWriteRepository = refreshTokenWriteRepository;
      //      //_refreshTokenReadRepository = refreshTokenReadRepository;
      //      _sessionReadRepository = sessionReadRepository;
      //      _sessionWriteRepository = sessionWriteRepository;
      //  }

      //  public async Task<TokenDto> RegisterAsync(string userName, string email, string password, string roleName)
      //  {
      //      _passwordHasher.CreatePasswordHash(password, out byte[] hash, out byte[] salt);

      //      var role = _dbContext.Roles.FirstOrDefault(r => r.Name == roleName);


      //      var userRole = new AppUserRole
      //      {

      //          Role = role,
      //          RoleId = (await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName)).Id,


      //      };


      //      List<AppUserRole> appUserRoles = new();
      //      appUserRoles.Add(userRole);

      //      var appUser = new AppUser()
      //      {
      //          Id = Guid.NewGuid(),
      //          UserName = userName,
      //          Email = email,
      //          UserRoles = appUserRoles,
      //          PasswordHash = hash,
      //          PasswordSalt = salt,

      //      };
      //      //var refreshToken = await _tokenService.GenerateRefreshToken(appUser);
      //      //appUser.RefreshToken = refreshToken;
      //      //appUser.RefreshTokenId = refreshToken.Id;

      //      //var accessToken = _tokenService.GenerateToken(appUser);
      //      _dbContext.RefreshTokens.Add(appUser.RefreshToken);
      //      await _dbContext.AddAsync(appUser);

      //      await _dbContext.SaveChangesAsync();


      //      return new TokenDto
      //      {
      //          //AccessToken = accessToken,
      //          RefreshToken = appUser.RefreshToken,
      //          Expiration = DateTime.UtcNow.AddHours(1)
      //      };

      //  }

      //  public async Task<(string accessToken, string refreshToken, string userId)> LoginAsync(SignInDto signInDto)
      //  {
      //      AppUser user = await _appUserReadRepository.GetByUserNameAsync(signInDto.Username);
      //      if (user == null || !_passwordHasher.VerifyPasswordHash(signInDto.Password, user.PasswordHash, user.PasswordSalt))
      //      {
      //          throw new Exception("Invalid username or password");
      //      }


      //      var refreshToken2 = await _dbContext.RefreshTokens.FirstOrDefaultAsync(r => r.Id == user.RefreshTokenId);
      //      if (refreshToken2 != null)
      //      {
      //          _dbContext.Remove(refreshToken2);
      //      }
      //      //var tokenService = new TokenService(_configuration);
      //      var accessToken = string.Empty ;/* _tokenService.GenerateToken(user);*/
      //      //var refreshToken = await _tokenService.GenerateRefreshToken(user);

      //      user.RefreshToken = null;
      //      user.RefreshTokenId = Guid.Empty;
      //      //_dbContext.RefreshTokens.Remove(refreshToken.)
      //      //user.RefreshTokenId = refreshToken.Id;
      //      //user.RefreshToken = refreshToken;


      //      //_dbContext.Add(refreshToken);
      //      //await _dbContext.Set<RefreshToken>().AddAsync(refreshToken);

      //      //bool check = _refreshTokenWriteRepository.Update(refreshToken);
      //      bool check = _appUserWriteRepository.Update(user);

      //      await _dbContext.SaveChangesAsync();

      //      if (!check)
      //      {

      //          return (accessToken, user.RefreshToken.Token, user.Id.ToString());

      //      }
      //      else throw new Exception();
      //  }


      //  public async Task<bool> SignOutAsync(string userId)
      //  {
      //      // Kullanıcıya ait refresh token'ları getir
      //      var user = await _appUserReadRepository.GetByUserIdAsync(userId);

      //      //var storedRefreshTokens = _refreshTokenReadRepository.GetAll(false);
      //      //var token = await storedRefreshTokens.Include(rt => rt.User)
      //      //    .FirstOrDefaultAsync(rt => rt.UserId == Guid.Parse(userId) && rt.ExpiryDate > DateTime.UtcNow);
      //      //var token = await _refreshTokenReadRepository.GetByIdAsync(userId, false);

      //      var b = false;
      //      bool check = false;
      //      if (/*token != null &&*/ user != null)
      //      {
      //          user.RefreshToken = null;
      //          user.RefreshTokenId = Guid.Empty;
      //          //RefreshToken oldToken = await _refreshTokenReadRepository.GetByIdAsync(token.Id.ToString());
      //          //b = _refreshTokenWriteRepository.DeleteRefreshToken(oldToken);
      //          check = _appUserWriteRepository.Update(user);
      //      }

      //      await _dbContext.SaveChangesAsync();
      //      if ( check)
      //      {

      //          return false;
      //      }


      //      return true;

      //  }

      //  public async Task<CookieDto> SignInAsync(SignInRequestDto requestDto)
      //  {
      //      // Kullanıcıyı kimlik doğrulamasıyla işle
      //      // Örneğin, kullanıcı adı ve şifresini kontrol et, doğruysa oturum bilgisi ve yenileme token'ı oluştur

      //      AppUser user = await _appUserReadRepository.GetByUserNameAsync(requestDto.Username);

      //      var session = new Session
      //      {
      //          Id = Guid.NewGuid(),
      //          UserId = user.Id, // Kullanıcı kimliği
      //          ClientRealIp = requestDto.ClientIpAddress,
      //          ClientUserAgent = requestDto.ClientUserAgent,
      //          ExpiredAt = DateTime.UtcNow.AddMinutes(30) // Örneğin, oturum süresi 30 dakika
      //      };

      //      var refreshTokenId = Guid.NewGuid();// Yeni bir refresh token ID oluştur
      //      var refreshTokenExpiration = DateTime.UtcNow.AddMinutes(1); // Refresh token süresi 24 saat

      //      var refreshTokenValidation = new RefreshTokenValidation
      //      {
      //          Id = refreshTokenId,
      //          UserId = user.Id,
      //          ExpiredAt = refreshTokenExpiration
      //      };

      //      user.Session = null;
      //      user.RefreshTokenValidation = null;
      //      user.RefreshTokenValidationId = null;


      //      user.Session = session;
      //      user.RefreshTokenValidation = refreshTokenValidation;
      //      user.RefreshTokenValidationId = refreshTokenValidation.Id.ToString();

      //      // Session ve refresh token bilgilerini veritabanına kaydet
      //      _dbContext.Sessions.Add(session);
      //      _dbContext.RefreshTokenValidations.Add(refreshTokenValidation);
      //      bool check = _appUserWriteRepository.Update(user);
      //      await _dbContext.SaveChangesAsync();

      //      // CookieDto oluştur ve döndür
      //      var cookieDto = new CookieDto
      //      {
      //          Session = session,
      //          RefreshTokenValidation = refreshTokenValidation
      //      };

      //      if (!check)
      //      {

      //          return cookieDto;
      //      }
      //      throw new Exception();

      //  }

      //  public async Task SignOutAsync(string sessionCookieValue, string refreshTokenCookieValue)
      //  {
      ////      // Oturumu ve refresh token'ı veritabanından sil
      ////      var session = await _dbContext.Sessions.FirstOrDefaultAsync(s => (s.Id).ToString() == sessionCookieValue);
      ////      var refreshToken = await _dbContext.RefreshTokenValidations.FirstOrDefaultAsync(rt => rt.Id.ToString() == refreshTokenCookieValue);
      ////      var user = await _dbContext.AppUsers.FirstOrDefaultAsync(u => (u.Session.Id).ToString() == sessionCookieValue);


      ////      //var storedRefreshTokens = _refreshTokenReadRepository.GetAll(false);
      ////      //var token = await storedRefreshTokens.Include(rt => rt.User)
      ////      //    .FirstOrDefaultAsync(rt => rt.UserId == user.Id && rt.ExpiryDate > DateTime.UtcNow);
      ////      //var token = await _refreshTokenReadRepository.GetByIdAsync(userId, false);

          
      ////      if (/*token != null && */user != null)
      ////      {
      ////          user.RefreshToken = null;
      ////          user.RefreshTokenId = Guid.Empty;
      //////          RefreshToken oldToken = await _refreshTokenReadRepository.GetByIdAsync(token.Id.ToString());
      //////_refreshTokenWriteRepository.DeleteRefreshToken(oldToken);
      ////      }

            

      ////      if (user != null)
      ////      {
      ////          user.RefreshTokenValidation = null;
      ////          user.RefreshTokenValidationId = null;
      ////          user.Session = null;
      ////      }
      ////      _appUserWriteRepository.Update(user);

      ////      if (session != null)
      ////      {
      ////          _dbContext.Sessions.Remove(session);
      ////      }

      ////      if (refreshToken != null)
      ////      {
      ////          _dbContext.RefreshTokenValidations.Remove(refreshToken);
      ////      }

      ////      await _dbContext.SaveChangesAsync();
      //  }

      //  public async Task<CookieDto> CreateUserAsync(CreateCommandUserRequestDto createCommandUserRequestDto)
      //  {
      //      _passwordHasher.CreatePasswordHash(createCommandUserRequestDto.Password, out byte[] hash, out byte[] salt);

      //      var role = _dbContext.Roles.FirstOrDefault(r => r.Name == createCommandUserRequestDto.RoleName);


      //      var userRole = new AppUserRole
      //      {

      //          Role = role,
      //          RoleId = (await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == createCommandUserRequestDto.RoleName)).Id,


      //      };


      //      List<AppUserRole> appUserRoles = new();
      //      appUserRoles.Add(userRole);

      //      var appUser = new AppUser()
      //      {
      //          Id = Guid.NewGuid(),
      //          UserName = createCommandUserRequestDto.UserName,
      //          Email = createCommandUserRequestDto.Email,
      //          UserRoles = appUserRoles,
      //          PasswordHash = hash,
      //          PasswordSalt = salt,

      //      };
      //      //var refreshToken = await _tokenService.GenerateRefreshToken(appUser);
      //      //appUser.RefreshToken = refreshToken;
      //      //appUser.RefreshTokenId = refreshToken.Id;

      //      //var accessToken = _tokenService.GenerateToken(appUser);
      //      //_dbContext.RefreshTokens.Add(appUser.RefreshToken);

      //      //await _dbContext.SaveChangesAsync();
      //      var session = new Session
      //      {
      //          Id = Guid.NewGuid(),
      //          UserId = appUser.Id, // Kullanıcı kimliği
      //          ClientRealIp = createCommandUserRequestDto.ClientIpAddress,
      //          ClientUserAgent = createCommandUserRequestDto.ClientUserAgent,
      //          ExpiredAt = DateTime.UtcNow.AddMinutes(30) // Örneğin, oturum süresi 30 dakika
      //      };

      //      var refreshTokenId = Guid.NewGuid().ToString(); // Yeni bir refresh token ID oluştur
      //      var refreshTokenExpiration = DateTime.UtcNow.AddHours(24); // Refresh token süresi 24 saat

      //      var refreshTokenValidation = new RefreshTokenValidation
      //      {
      //          Id = Guid.Parse(refreshTokenId),
      //          UserId = appUser.Id,
      //          ExpiredAt = refreshTokenExpiration
      //      };

      //      appUser.RefreshTokenValidationId = refreshTokenValidation.Id.ToString();
      //      appUser.RefreshTokenValidation = refreshTokenValidation;
      //      await _dbContext.AddAsync(appUser);

      //      // Session ve refresh token bilgilerini veritabanına kaydet
      //      _dbContext.Sessions.Add(session);
      //      _dbContext.RefreshTokenValidations.Add(refreshTokenValidation);
      //      await _dbContext.SaveChangesAsync();

      //      // CookieDto oluştur ve döndür
      //      var cookieDto = new CookieDto
      //      {
      //          Session = session,
      //          RefreshTokenValidation = refreshTokenValidation
      //      };

      //      return cookieDto;

      //  }
      //  //public async Task<CookieDto> SignInAsync(SignInRequestDto requestDto)
      //  //{
      //  //    // Kullanıcıyı kimlik doğrulamasıyla işle
      //  //    // Örneğin, kullanıcı adı ve şifresini kontrol et, doğruysa oturum bilgisi ve yenileme token'ı oluştur

      //  //    AppUser User = await _appUserReadRepository.GetByUserNameAsync(requestDto.Username);

      //  //    var session = new Session
      //  //    {
      //  //        Id = Guid.NewGuid().ToString(),
      //  //        UserId = User.Id, // Kullanıcı kimliği
      //  //        ClientRealIp = requestDto.ClientIpAddress,
      //  //        ClientUserAgent = requestDto.ClientUserAgent,
      //  //        ExpiredAt = DateTime.UtcNow.AddMinutes(30) // Örneğin, oturum süresi 30 dakika
      //  //    };

      //  //    var refreshTokenId = Guid.NewGuid().ToString(); // Yeni bir refresh token ID oluştur
      //  //    var refreshTokenExpiration = DateTime.UtcNow.AddHours(24); // Refresh token süresi 24 saat

      //  //    var refreshTokenValidation = new RefreshTokenValidation
      //  //    {
      //  //        RefreshTokenId = refreshTokenId,
      //  //        UserId = User.Id,
      //  //        ExpiredAt = refreshTokenExpiration
      //  //    };

      //  //    // Session ve refresh token bilgilerini veritabanına kaydet (veya başka bir depolama mekanizması kullan)
      //  //    // ...

      //  //    // CookieDto oluştur ve döndür
      //  //    var cookieDto = new CookieDto
      //  //    {
      //  //        Session = session,
      //  //        RefreshTokenValidation = refreshTokenValidation
      //  //    };

      //  //    return cookieDto;
      //  // }

      //  public async Task ValidateAsync(string session, string clientUserAgent, string clientRealIp)
      //  {
      //      var validSession = (await _dbContext.Sessions.FindAsync(session)).Adapt<SessionDto>();

      //      bool isSessionExpired = validSession.ExpiredAt.ToUniversalTime() <= DateTime.UtcNow;
      //      if (!string.Equals(validSession.ClientRealIp, clientRealIp) ||
      //          !string.Equals(validSession.ClientUserAgent, clientUserAgent, StringComparison.OrdinalIgnoreCase))
      //      {
      //          throw new Exception();
      //      }

      //      if (isSessionExpired)
      //      {
      //          throw new Exception();
      //      }
      //  }
      //  public async Task<SessionDto> GetSessionAsync(string sessionId)
      //  {
      //      var query =  _sessionReadRepository.GetAll(false);

      //      var session =  await query.FirstOrDefaultAsync(s => s.Id == Guid.Parse(sessionId));

      //      SessionDto sessionDto = session.Adapt<SessionDto>();
      //      return sessionDto;

      //  }

      //  public async Task<SessionDto> RefreshSessionAsync(string refreshTokenId, string userAgent, string realIp)
      //  {
      //      //var token = await _refreshTokenReadRepository.GetByIdAsync(refreshTokenId);
      //      //if (token == null || token.ExpiredAt < DateTime.UtcNow)
      //      //{
      //      //    return null;
      //      //}


      //      //// Create new session
      //      //var newSession = new Session
      //      //{
      //      //    Id = Guid.NewGuid(),
      //      //    UserId = token.UserId,
      //      //    ClientUserAgent = userAgent,
      //      //    ClientRealIp = realIp,
      //      //    ExpiredAt = DateTime.UtcNow.AddHours(1) // Örneğin 1 saat geçerli
      //      //};


      //      //await _sessionWriteRepository.AddAsync(newSession);
      //      //SessionDto sessionDto = newSession.Adapt<SessionDto>();

      //      //return sessionDto;
      //      return null;
      //  }



    }
}

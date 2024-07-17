//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using StartupShopping.Application.Abstractions.Token_Password;
//using StartupShopping.Application.Repositories.AppUserRepository;
//using StartupShopping.Application.Repositories.RefreshTokenRepository;
//using StartupShopping.Domain.Entities;
//using StartupShopping.Domain.Entities.Jwt;
//using StartupShopping.Persistance.Contexts;
//using StartupShopping.Persistance.Repositories.RefreshTokenRepository;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;

//namespace StartupShopping.Infrastructure.Services.Token_Password
//{
//    public class TokenService : ITokenService
//    {
//        private readonly IConfiguration _configuration;
//        private readonly JwtSettings _jwtSettings;
//        private readonly StartupShoppingDbContext _context;

//        private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;
//        //private readonly IRefreshTokenReadRepository _refreshTokenReadRepository;
//        private readonly IAppUserReadRepository _appUserReadRepository;

//        public TokenService(IConfiguration configuration, IOptions<JwtSettings> jwtSettings, StartupShoppingDbContext context/*, IRefreshTokenWriteRepository refreshTokenWriteRepository, IRefreshTokenReadRepository refreshTokenReadRepository, IAppUserReadRepository appUserReadRepository*/)
//        {
//            _configuration = configuration;
//            _jwtSettings = jwtSettings.Value;
//            _context = context;
//            //_refreshTokenWriteRepository = refreshTokenWriteRepository;
//            ////_refreshTokenReadRepository = refreshTokenReadRepository;
//            //_appUserReadRepository = appUserReadRepository;
//        }

//        public string GenerateToken(AppUser user)
//        {
//            var authClaims = new List<Claim>
//                             {
//                                new Claim(ClaimTypes.Name, user.UserName),
//                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//                                };

//            foreach (var role in user.UserRoles)
//            {
//                authClaims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
//            }

//            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret));

//            var token = new JwtSecurityToken(
//                issuer: _jwtSettings.Issuer,
//                audience: _jwtSettings.Audience,
//                expires: DateTime.Now.AddSeconds(_jwtSettings.AccessTokenExpiration),
//                claims: authClaims,
//                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
//            );


//            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
//            return jwtToken;
//            ///////////////////////////////////////////
//            //                    var tokenHandler = new JwtSecurityTokenHandler();
//            //                    var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);

//            //                    var claims = new List<Claim>
//            //            {
//            //            new Claim(ClaimTypes.Name, user.UserName),
//            //            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
//            //                 };

//            //// Kullanıcı rollerini claims'e ekleme
//            //foreach (var role in user.UserRoles)
//            //{
//            //    claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
//            //}

//            //var tokenDescriptor = new SecurityTokenDescriptor
//            //{
//            //    Subject = new ClaimsIdentity(claims),
//            //    Expires = DateTime.UtcNow.AddMinutes(15),
//            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            //};

//            //var token = tokenHandler.CreateToken(tokenDescriptor);
//            //return tokenHandler.WriteToken(token);
//        }


//        public async Task<RefreshToken> GenerateRefreshToken(AppUser user)
//        {
//            //var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == Guid.Parse( userId));
//            var refreshToken = new RefreshToken
//            {
//                Id = Guid.NewGuid(),
//                Token = Guid.NewGuid().ToString(),
//                ExpiryDate = DateTime.UtcNow.AddDays(30),
//                UserId = user.Id,
//                User = user,
//            };
//            _context.RefreshTokens.Add(refreshToken);
//            //_context.AppUsers.Update(user);

//            //await _context.SaveChangesAsync();

//            //return new RefreshToken
//            //{
//            //    Token = refreshToken.Token,
//            //    ExpiryDate = DateTime.UtcNow.AddDays(30),
//            //    UserId = Guid.Parse(userId),
//            //    User = user
//            //};
//            return refreshToken;
//        }

//        public async Task<string> RefreshAccessToken(string refreshToken)
//        {
//            var token = await _context.RefreshTokens.Include(r => r.User)
//                                .FirstOrDefaultAsync(r => r.Token == refreshToken && r.IsRevoked);



//            if (token == null)
//            {
//                throw new SecurityTokenException("Invalid token");
//            }

//            var newAccessToken = GenerateToken(token.User); // JWT token oluşturma fonksiyonunuz
//            //var newRefreshToken = GenerateRefreshToken(token.User); // JWT token oluşturma fonksiyonunuz

//            // Yeni refresh token oluştur
//            //token.Token = Guid.NewGuid().ToString();
//            //token.ExpiryDate = DateTime.UtcNow.AddDays(7);

            
//            //_context.RefreshTokens.Update(token);
//            //await _context.SaveChangesAsync();

//            return newAccessToken;
//        }
//        //public async Task<AppUser> ValidateRefreshToken(string refreshToken)
//        //{

//        //    try
//        //    {
//        //        var storedRefreshTokens = _refreshTokenReadRepository.GetAll(false);
//        //        var token = await storedRefreshTokens.Include(rt => rt.User)
//        //            .FirstOrDefaultAsync(rt => rt.Token == refreshToken && rt.ExpiryDate > DateTime.UtcNow);

//        //        if (token == null)
//        //        {
//        //            return null; // Geçersiz veya süresi dolmuş refresh token
//        //        }
//        //        var b = false;
//        //        // Kullanıcı rollerini dahil ederek kullanıcı nesnesini döndür
//        //        var user = await _appUserReadRepository.GetByUserIdAsync(token.UserId.ToString());

//        //        if (user != null && token != null)
//        //        {
//        //            RefreshToken oldToken = await _refreshTokenReadRepository.GetByIdAsync(token.Id.ToString());
//        //            b = _refreshTokenWriteRepository.DeleteRefreshToken(oldToken);

//        //        }
//        //        if (b)
//        //        {
//        //            return user;
//        //        }
//        //        else
//        //        {
//        //            throw new InvalidOperationException();
//        //        }

//        //        //if (user != null)
//        //        //{
//        //        //    await _context.Entry(user).Collection(u => u.UserRoles).LoadAsync();
//        //        //}


//        //    }
//        //    catch (Exception ex)
//        //    {

//        //        throw ex;
//        //    }

//        //}
//    }
//}

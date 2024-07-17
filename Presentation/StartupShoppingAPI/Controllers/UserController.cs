using Ardalis.GuardClauses;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using StartupShopping.Application.Abstractions.Auth;
using StartupShopping.Application.Abstractions.Identity;
using StartupShopping.Application.Abstractions.Token_Password;
using StartupShopping.Application.DTO_s;
using StartupShopping.Application.Features.Commands.AppUser.NewToken;
using StartupShopping.Application.Features.Commands.AppUser.SignIn;
using StartupShopping.Application.Repositories.AppUserRepository;
using StartupShopping.Application.Repositories.RefreshTokenRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Domain.Entities.Jwt;
using StartupShopping.Infrastructure.Services.Token_Password;
using StartupShopping.Persistance.Contexts;
using StartupShoppingAPI.Cookie;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace StartupShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAppUserReadRepository _appUserReadRepository;
        private readonly IAppUserWriteRepository _appUserWriteRepository;

        //private readonly IRefreshTokenReadRepository _refreshTokenReadRepository;
        //private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;
        private readonly StartupShoppingDbContext _context;

        private readonly IAuthService _authService;

        private readonly IUserManager _userManager;
        //private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        private readonly IMediator _mediator;

        private readonly JwtSettings _jwtSettings;

        public UserController(IAppUserReadRepository appUserReadRepository, IAppUserWriteRepository appUserWriteRepository, IUserManager userManager, /*ITokenService tokenService,*/ IConfiguration configuration, IAuthService authService, JwtSettings jwtSettings, /*IRefreshTokenReadRepository refreshTokenReadRepository, IRefreshTokenWriteRepository refreshTokenWriteRepository,*/ IMediator mediator)
        {
            _appUserReadRepository = appUserReadRepository;
            _appUserWriteRepository = appUserWriteRepository;
            _userManager = userManager;
            //_tokenService = tokenService;
            _configuration = configuration;
            _authService = authService;
            _jwtSettings = jwtSettings;
            //_refreshTokenReadRepository = refreshTokenReadRepository;
            //_refreshTokenWriteRepository = refreshTokenWriteRepository;
            _mediator = mediator;
        }

        //[AllowAnonymous]
        //[HttpPost("signin")]
        //public async Task<IActionResult> SignIn([FromBody] SignInCommandRequest signInCommandRequest)
        //{


        //    SignInCommandResponse signInCommandResponse = await _mediator.Send(signInCommandRequest);


        //    return Ok(signInCommandResponse);

        //}

        [AllowAnonymous]
        [HttpGet("protected")]
        public IActionResult ProtectedEndpoint()
        {
            return Ok("This is a protected endpoint.");
        }

        [AllowAnonymous]
        [HttpPost("newTokenWithRefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] NewTokenCommandRequest newTokenCommandRequest)
        {

            NewTokenCommandResponse newTokenCommandResponse = await _mediator.Send(newTokenCommandRequest);
            return Ok(newTokenCommandResponse);


        }

        ////[AllowAnonymous]
        [HttpPost("SignOut")]
        public async Task<bool> SignOut([FromBody] SignOutRequest request)
        {
            //var result = await _authService.SignOutAsync(request.userId);
            //return result;
            return false;
        }
        //private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        //{
        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateAudience = false, // you might want to validate the audience and issuer depending on your use case
        //        ValidateIssuer = false,
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
        //        ValidateLifetime = false // we want to get claims from expired tokens
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    SecurityToken securityToken;
        //    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        //    var jwtSecurityToken = securityToken as JwtSecurityToken;

        //    if (jwtSecurityToken == null ||
        //        !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        throw new SecurityTokenException("Invalid token");
        //    }

        //    return principal;
        //}

        [AllowAnonymous]
        [HttpPost("sign-in")]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public async Task<ApiResponse> SignInAsync([FromBody] SignInRequest request)
        {
            //SignInRequestDto requestDto = request.Adapt<SignInRequestDto>();

            //string? clientRealIp = Request.Headers.TryGetValue("X-Client-Ip", out StringValues ipAddr)
            //? ipAddr
            //    : Request.HttpContext.Connection.RemoteIpAddress?.ToString();

            //requestDto.ClientIpAddress = Guard.Against.Null(clientRealIp);
            //requestDto.ClientUserAgent = Request.Headers[HeaderNames.UserAgent].ToString();

            //CookieDto signInResponse = await _authService.SignInAsync(requestDto);

            //var cookieOptions = new CookieOptions
            //{
            //    Expires = signInResponse.Session.ExpiredAt,
            //    Secure = true,
            //    HttpOnly = true,
            //    IsEssential = true,
            //    Path = "/",
            //    Domain = "localhost",
            //    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict
            //};

            //HttpContext.Response.Cookies.Append(Cookies.SESSION_KEY, (signInResponse.Session.Id).ToString(), cookieOptions);
            //HttpContext.Response.Cookies.Append(Cookies.REFRESHTOKEN_KEY, signInResponse.RefreshTokenValidation.Id.ToString(), cookieOptions);

            //return new ApiResponse { Result = true ,RefreshTokenValidation = signInResponse.RefreshTokenValidation,Session = signInResponse.Session};
            return null;
        }

        //[AllowAnonymous]
        [HttpPost("sign-out")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public async Task<ApiResponse> SignOutAsync()
        {
            //var currentSession = HttpContext.Request.Cookies.FirstOrDefault(cookie => cookie.Key == Cookies.SESSION_KEY).Value;
            //var currentRefreshToken = HttpContext.Request.Cookies.FirstOrDefault(cookie => cookie.Key == Cookies.REFRESHTOKEN_KEY).Value;

            //await _authService.SignOutAsync(currentSession, currentRefreshToken);

            //HttpContext.Response.Cookies.Delete(Cookies.SESSION_KEY);
            //HttpContext.Response.Cookies.Delete(Cookies.REFRESHTOKEN_KEY);

            //return new ApiResponse { Result = true };
            return null;
        }

    }
}

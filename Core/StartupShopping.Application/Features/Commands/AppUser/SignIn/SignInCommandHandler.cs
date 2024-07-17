using MediatR;
using StartupShopping.Application.Abstractions.Auth;
using StartupShopping.Application.DTO_s;
using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Commands.AppUser.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommandRequest, SignInCommandResponse>
    {
        private readonly IAuthService _authService;

        public SignInCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<SignInCommandResponse> Handle(SignInCommandRequest request, CancellationToken cancellationToken)
        {
            //SignInDto signInDto = new SignInDto {Username = request.Username, Password = request.Password };
            //var(accessToken, refreshToken,userId) =  await _authService.LoginAsync(signInDto);


            //return new SignInCommandResponse
            //{
            //    Message = "Successfull",
            //    Succeeded = true,
            //    UserId = userId,
            //    UserName = request.Username,
            //    TokenDto = new TokenModel { AccessToken = accessToken, RefreshToken = refreshToken,ExpireTime = DateTime.Now.AddMinutes(7)},
            //};
            throw new NotImplementedException();
        }
    }

      
}

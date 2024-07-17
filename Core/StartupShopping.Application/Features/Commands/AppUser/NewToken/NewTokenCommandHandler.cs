using MediatR;
using StartupShopping.Application.Abstractions.Token_Password;
using StartupShopping.Application.DTO_s;
using StartupShopping.Application.Repositories.AppUserRepository;
using StartupShopping.Application.Repositories.RefreshTokenRepository;
using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Commands.AppUser.NewToken
{
    public class NewTokenCommandHandler : IRequestHandler<NewTokenCommandRequest, NewTokenCommandResponse>
    {
        //private readonly ITokenService _tokenService;
        private readonly IAppUserReadRepository _appUserReadRepository;
        private readonly IAppUserWriteRepository _appUserWriteRepository;
        //private readonly IRefreshTokenWriteRepository _refreshTokenWriteRepository;

        public NewTokenCommandHandler(/*ITokenService tokenService,*/ IAppUserReadRepository appUserReadRepository, /*IRefreshTokenWriteRepository refreshTokenWriteRepository,*/ IAppUserWriteRepository appUserWriteRepository)
        {
            //_tokenService = tokenService;
            _appUserReadRepository = appUserReadRepository;
            //_refreshTokenWriteRepository = refreshTokenWriteRepository;
            _appUserWriteRepository = appUserWriteRepository;
        }

        public async Task<NewTokenCommandResponse> Handle(NewTokenCommandRequest request, CancellationToken cancellationToken)
        {
            //var user = await _tokenService.ValidateRefreshToken(request.refreshToken);

            //if (user == null)
            //{
            //    throw new Exception();// geçersiz refresh token durumu
            //}
            //var accessToken = _tokenService.GenerateToken(user);
            //var newRefreshToken = await _tokenService.GenerateRefreshToken(user);

            //user.RefreshToken = null;
            //user.RefreshTokenId = Guid.Empty;

            //user.RefreshTokenId = newRefreshToken.Id;
            //user.RefreshToken = newRefreshToken;

            //_appUserWriteRepository.Update(user);

            //await _refreshTokenWriteRepository.SaveAsync();

            //return new NewTokenCommandResponse
            //{
            //   tokenModel =  new TokenModel {AccessToken = accessToken,RefreshToken = newRefreshToken.Token,ExpireTime = DateTime.Now.AddMinutes(7)},
            //};
            throw new NotImplementedException();

        }
    }
}

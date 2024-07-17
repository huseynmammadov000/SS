//using StartupShopping.Application.Abstractions.Identity;
//using StartupShopping.Application.Abstractions.Token_Password;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace StartupShopping.Infrastructure.Services.Identity
//{
//    //public class SignInManager : ISignInManager
//    //{
//    //    private readonly IUserManager _userManager;
//    //    //private readonly ITokenService _tokenService;

//    //    public SignInManager(IUserManager userManager/*, ITokenService tokenService*/)
//    //    {
//    //        _userManager = userManager;
//    //        //_tokenService = tokenService;
//    //    }

//    //    public async Task<string> SignInAsync(string username, string password)
//    //    {
//    //        var user = await _userManager.FindByUsernameAsync(username);
//    //        if (user == null || !await _userManager.CheckPasswordAsync(user, password))
//    //            throw new Exception("Invalid username or password");

//    //        //return _tokenService.GenerateToken(user);
//    //        return null;
//    //    }

//    //    public Task SignOutAsync()
//    //    {
//    //        return Task.CompletedTask;
//    //    }
//    //}
//}

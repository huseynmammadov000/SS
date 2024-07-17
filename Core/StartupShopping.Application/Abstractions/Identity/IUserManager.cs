using StartupShopping.Application.DTO_s;
using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Abstractions.Identity
{
    public interface IUserManager
    {
        Task<AppUser> FindByUsernameAsync(string username);
        Task<AppUser> FindByEmailAsync(string email);
        Task<TokenDto> CreateUserAsync(string userName,string email, string password,string passwordConfirm,string roleName);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
    }
}

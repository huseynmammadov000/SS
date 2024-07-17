using StartupShopping.Application.DTO_s;
using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Repositories.AppUserRepository
{
    public interface IAppUserWriteRepository:IWriteRepository<AppUser>
    {
        //Task<TokenDto> CreateUser(string userName,string email,string password,string roleName);
    }
}

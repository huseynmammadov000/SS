using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Repositories.AppUserRepository
{
    public interface IAppUserReadRepository:IReadRepository<AppUser>
    {
        Task<AppUser?> GetByUserNameAsync(string userName);
        Task<AppUser?> GetByEmailAsync(string email);
        Task<AppUser?> GetByUserIdAsync(string userId);
        Task<string> GetByAllRoles(string userId);
    }
}

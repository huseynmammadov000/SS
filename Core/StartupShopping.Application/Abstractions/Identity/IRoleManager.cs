using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Abstractions.Identity
{
    public interface IRoleManager
    {
        Task<bool> RoleExistsAsync(string roleName);
        Task<bool> CreateRoleAsync(string roleName);
        Task AssignRoleAsync(AppUser user, string roleName);
        Task<Role> FindByNameAsync(string name);
    }
}

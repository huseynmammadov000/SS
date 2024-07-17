using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StartupShopping.Application.Abstractions.Identity;
using StartupShopping.Domain.Entities;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Infrastructure.Services.Identity
{
    public class RoleManager : IRoleManager
    {
        private readonly StartupShoppingDbContext _startupShoppingDbContext;

        public RoleManager(StartupShoppingDbContext startupShoppingDbContext)
        {
            _startupShoppingDbContext = startupShoppingDbContext;
        }

        public RoleManager()
        {
            
        }
        public async Task AssignRoleAsync(AppUser user, string roleName)
        {
            var role = await _startupShoppingDbContext.Roles.SingleOrDefaultAsync(r => r.Name == roleName);
            if (role == null)
                throw new Exception("Role not found");

            Role role1 = new Role { Name = roleName };
            AppUserRole userRole = new AppUserRole
            {
                RoleId = role1.Id,
               
            };

          
            user.UserRoles.Add(userRole);
                  // Basit bir atama, role-based authorization için geliştirebilirsiniz
            _startupShoppingDbContext.AppUsers.Update(user);
            await _startupShoppingDbContext.SaveChangesAsync();
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            if (!await RoleExistsAsync(roleName))
            {
                var role = new Role { Name = roleName };
                await _startupShoppingDbContext.Roles.AddAsync(role);
                await _startupShoppingDbContext.SaveChangesAsync();
                return true;
            }
            else throw new NotImplementedException();
        }

        public async Task<Role> FindByNameAsync(string name)
        {
           var role = await _startupShoppingDbContext.Roles.FirstOrDefaultAsync(r => r.Name == name);
            if (role != null)
            {
                Role appUserRole = new Role { Name = name };
                return appUserRole;
            }
            else throw new Exception();
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _startupShoppingDbContext.Roles.AnyAsync(r => r.Name == roleName);
        }
    }
}

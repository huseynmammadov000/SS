using Microsoft.AspNetCore.Identity;
using StartupShopping.Application.Abstractions.Identity;
using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Infrastructure.Services.Identity
{
    public class RoleSeedService
    {
        private readonly IRoleManager _roleManager;

        public RoleSeedService()
        {
            
        }
        public RoleSeedService(IRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

       
        public async Task SeedRolesAsync()
        {
            string[] roleNames = { "Admin", "Entrepreneur", "Investor" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await _roleManager.CreateRoleAsync(roleName);
                }
            }
        }
    }

}

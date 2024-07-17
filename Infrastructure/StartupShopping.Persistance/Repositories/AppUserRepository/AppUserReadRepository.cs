using Microsoft.EntityFrameworkCore;
using StartupShopping.Application.Repositories.AppUserRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories.AppUserRepository
{
    public class AppUserReadRepository : ReadRepository<AppUser>, IAppUserReadRepository
    {
        private readonly StartupShoppingDbContext _dbContext;
        public AppUserReadRepository(StartupShoppingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AppUser?> GetByEmailAsync(string email)
        {
            //return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            //return await _dbContext.
            var query = _dbContext.Set<AppUser>().AsQueryable();
            return await query.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<AppUser?> GetByUserNameAsync(string userName)
        {
            var query = _dbContext.Set<AppUser>()
                          .Include(u => u.UserRoles)
                          .ThenInclude(ur => ur.Role)
                          .AsQueryable();
            var tokenQuery = _dbContext.Set<RefreshToken>()
                .Include(r => r.User);



            var user = await query.FirstOrDefaultAsync(u => u.UserName == userName);
            var token = await tokenQuery.FirstOrDefaultAsync(rt=> rt.UserId == user.Id);
            user.RefreshToken = token;
            return user;
        }

        public async Task<AppUser?> GetByUserIdAsync(string userId)
        {
            var query = _dbContext.Set<AppUser>()
                          .Include(u => u.UserRoles)
                          .ThenInclude(ur => ur.Role)
                          .AsQueryable();

            return await query.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));
        }

        public Task<string> GetByAllRoles(string userId)
        {
            return null;
        }
    }
}

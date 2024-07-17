using Microsoft.EntityFrameworkCore;
using StartupShopping.Application.Repositories.SessionRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Domain.Entities.Models;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories.SessionRepository
{
    public class SessionReadRepository : ReadRepository<Session>, ISessionReadRepository
    {
        private readonly StartupShoppingDbContext _dbContext;
        public SessionReadRepository(StartupShoppingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Session> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}

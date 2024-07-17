using StartupShopping.Application.Repositories;
using StartupShopping.Application.Repositories.SessionRepository;
using StartupShopping.Domain.Entities.Models;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories.SessionRepository
{
    public class SessionWriteRepository : WriteRepository<Session>, ISessionWriteRepository
    {
        public SessionWriteRepository(StartupShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}

using StartupShopping.Application.Repositories.PortfolioRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories.PortfolioRepository
{
    public class PortfolioReadRepository : ReadRepository<Portfolio>, IPortfolioReadRepository
    {
        public PortfolioReadRepository(StartupShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}

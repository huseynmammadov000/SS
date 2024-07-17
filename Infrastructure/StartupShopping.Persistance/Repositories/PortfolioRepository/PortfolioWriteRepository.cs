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
    public class PortfolioWriteRepository : WriteRepository<Portfolio>, IPortfolioWriteRepository
    {
        public PortfolioWriteRepository(StartupShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}

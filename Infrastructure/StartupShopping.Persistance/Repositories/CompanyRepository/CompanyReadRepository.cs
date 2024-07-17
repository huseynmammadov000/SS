using StartupShopping.Application.Repositories.CompanyRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories.CompanyRepository
{
    public class CompanyReadRepository : ReadRepository<Company>, ICompanyReadRepository
    {
        public CompanyReadRepository(StartupShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}

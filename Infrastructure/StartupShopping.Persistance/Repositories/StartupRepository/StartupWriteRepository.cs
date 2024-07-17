using StartupShopping.Application.Repositories.StartupRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Persistance.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories.StartupRepository
{
    public class StartupWriteRepository : WriteRepository<Startup>, IStartupWriteRepository
    {
        public StartupWriteRepository(StartupShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}

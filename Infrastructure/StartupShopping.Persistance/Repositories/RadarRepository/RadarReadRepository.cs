using StartupShopping.Application.Repositories.RadarRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories.RadarRepository
{
    public class RadarReadRepository : ReadRepository<Radar>, IRadarReadRepository
    {
        public RadarReadRepository(StartupShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}

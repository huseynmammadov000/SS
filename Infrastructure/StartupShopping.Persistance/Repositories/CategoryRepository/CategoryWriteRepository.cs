using StartupShopping.Application.Repositories.CategoryRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories.CategoryRepository
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(StartupShoppingDbContext dbContext) : base(dbContext)
        {
        }
    }
}

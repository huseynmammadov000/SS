using StartupShopping.Application.DTO_s;
using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Repositories.StartupRepository
{
    public interface IStartupReadRepository:IReadRepository<Startup>
    {
       public Task<PageResult<StartupGetDto>> GetPagedStartupsWithCategoryAsync(int pageSize, int pageNumber, string categoryIds);
        public Task<PageResult<StartupGetDto>> GetPagedStartupsAsync(int pageSize, int pageNumber);
    }
}

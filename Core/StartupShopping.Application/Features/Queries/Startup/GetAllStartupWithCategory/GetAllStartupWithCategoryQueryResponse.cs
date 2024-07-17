using StartupShopping.Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Queries.Startup.GetAllStartupWithCategory
{
    public class GetAllStartupWithCategoryQueryResponse
    {
        public PageResult<StartupGetDto> PageResult { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Queries.Startup.GetAllStartupWithCategory
{
    public class GetAllStartupWithCategoryQueryRequest :IRequest<GetAllStartupWithCategoryQueryResponse>
    {
        const int maxPageSize = 500;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
        public string CategoryIds { get; set; }
    }
}

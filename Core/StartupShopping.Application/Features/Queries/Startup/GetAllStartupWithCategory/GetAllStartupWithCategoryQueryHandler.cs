using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StartupShopping.Application.DTO_s;
using StartupShopping.Application.Features.Queries.Startup.GetAllStartup;
using StartupShopping.Application.Repositories.StartupRepository;
using StartupShopping.Application.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Queries.Startup.GetAllStartupWithCategory
{
    public class GetAllStartupWithCategoryQueryHandler : IRequestHandler<GetAllStartupWithCategoryQueryRequest, GetAllStartupWithCategoryQueryResponse>
    {
        private readonly IStartupReadRepository _startupReadRepository;
        private readonly ILogger<GetAllStartupQueryHandler> _logger;

        public GetAllStartupWithCategoryQueryHandler(IStartupReadRepository startupReadRepository, ILogger<GetAllStartupWithCategoryQueryHandler> logger)
        {
            _startupReadRepository = startupReadRepository;
            //_logger = logger;
        }

       

        public async Task<GetAllStartupWithCategoryQueryResponse> Handle(GetAllStartupWithCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            

            var pagedStartups = await _startupReadRepository.GetPagedStartupsWithCategoryAsync(request.PageSize, request.PageNumber, request.CategoryIds);

            return new GetAllStartupWithCategoryQueryResponse
            {
                PageResult = pagedStartups
            };
        }
    }
}

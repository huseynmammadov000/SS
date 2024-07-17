using MediatR;
using Microsoft.Extensions.Logging;
using StartupShopping.Application.DTO_s;
using StartupShopping.Application.Features.Queries.Startup.GetAllStartupWithCategory;
using StartupShopping.Application.Repositories.StartupRepository;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Queries.Startup.GetAllStartup
{
    public class GetAllStartupQueryHandler : IRequestHandler<GetAllStartupQueryRequest, GetAllStartupQueryResponse>
    {
        private readonly IStartupReadRepository _startupReadRepository;
        private readonly ILogger<GetAllStartupQueryHandler> _logger;

        public GetAllStartupQueryHandler(IStartupReadRepository startupReadRepository, ILogger<GetAllStartupQueryHandler> logger)
        {
            _startupReadRepository = startupReadRepository;
            _logger = logger;
        }

        public async Task<GetAllStartupQueryResponse> Handle(GetAllStartupQueryRequest request, CancellationToken cancellationToken)
        {
            var pagedStartups = await _startupReadRepository.GetPagedStartupsAsync(request.PageSize, request.PageNumber);

            return new GetAllStartupQueryResponse
            {
                PageResult = pagedStartups
            };
        }
    }
}

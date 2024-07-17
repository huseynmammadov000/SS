using Microsoft.EntityFrameworkCore;
using StartupShopping.Application.DTO_s;
using StartupShopping.Application.Repositories.StartupRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories.StartupRepository
{
    public class StartupReadRepository : ReadRepository<Startup>, IStartupReadRepository
    {
        private readonly StartupShoppingDbContext _dbContext;
        public StartupReadRepository(StartupShoppingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PageResult<StartupGetDto>> GetPagedStartupsAsync(int pageSize, int pageNumber)
        {
            var query = _dbContext.Set<Startup>().AsQueryable();

            var totalItems = await query.CountAsync();
            Console.WriteLine($"Total items: {totalItems}");

            // Skip ve Take işlemleri
            var items = await query
                .Include(s => s.Category) // Category dahil edilmesini sağlar
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            Console.WriteLine($"Items count: {items.Count}");

            // Dto'ya dönüştürme
            var startupDtos = items.Select(s => new StartupGetDto
            {
                Id = s.Id,
                Name = s.StartupName,
                Description = s.StartupDescription,
                FoundationYear = s.FoundationYear,
                CategoryName = s.Category?.CategoryName,
                UserId = s.UserId,
                Active = s.active,
                LogoBase64 = s.Logo != null ? Convert.ToBase64String(s.Logo) : null
            }).ToList();
            Console.WriteLine($"DTO count: {startupDtos.Count}");

            return new PageResult<StartupGetDto>
            {
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                Items = startupDtos
            };
        }



        public async Task<PageResult<StartupGetDto>> GetPagedStartupsWithCategoryAsync(int pageSize, int pageNumber, string categoryIds)
        {
            var query = _dbContext.Set<Startup>().AsQueryable();

            // CategoryId filtreleme
            if (!string.IsNullOrEmpty(categoryIds))
            {
                var categoryIdsArray = categoryIds.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(Guid.Parse)
                                                  .ToList();

                if (categoryIdsArray.Any())
                {
                    query = query.Where(s => categoryIdsArray.Contains(s.CategoryId));
                }
            }

            var totalItems = await query.CountAsync();
            Console.WriteLine($"Total items: {totalItems}");

            // Skip ve Take işlemleri
            var items = await query
                .Include(s => s.Category) // Category dahil edilmesini sağlar
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            Console.WriteLine($"Items count: {items.Count}");

            // Dto'ya dönüştürme
            var startupDtos = items.Select(s => new StartupGetDto
            {
                Id = s.Id,
                Name = s.StartupName,
                Description = s.StartupDescription,
                FoundationYear = s.FoundationYear,
                CategoryName = s.Category?.CategoryName,
                UserId = s.UserId,
                Active = s.active,
                LogoBase64 = s.Logo != null ? Convert.ToBase64String(s.Logo) : null
            }).ToList();
            Console.WriteLine($"DTO count: {startupDtos.Count}");

            return new PageResult<StartupGetDto>
            {
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                Items = startupDtos
            };
        }


    }
}

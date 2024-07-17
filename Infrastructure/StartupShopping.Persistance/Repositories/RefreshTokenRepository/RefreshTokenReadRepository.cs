using StartupShopping.Application.Repositories.RefreshTokenRepository;
using StartupShopping.Domain.Entities;
using StartupShopping.Domain.Entities.Models;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories.RefreshTokenRepository
{
    //public class RefreshTokenReadRepository : ReadRepository<RefreshTokenValidation>, IRefreshTokenReadRepository
    //{
    //    private readonly IRefreshTokenReadRepository _repository;
    //    public RefreshTokenReadRepository(StartupShoppingDbContext dbContext, IRefreshTokenReadRepository repository) : base(dbContext)
    //    {
    //        _repository = repository;
    //    }

    //    //public Task<RefreshTokenValidation> GetByTokenAsync(string refreshToken)
    //    //{
    //    //    return;
    //    //}
    //}
}

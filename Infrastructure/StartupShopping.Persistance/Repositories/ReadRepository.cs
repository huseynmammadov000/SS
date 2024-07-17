using Microsoft.EntityFrameworkCore;
using StartupShopping.Application.DTO_s;
using StartupShopping.Application.Repositories;
using StartupShopping.Application.RequestParameters;
using StartupShopping.Domain.Entities;
using StartupShopping.Domain.Entities.Common;
using StartupShopping.Domain.Entities.Enum;
using StartupShopping.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly StartupShoppingDbContext _dbContext;

        public ReadRepository(StartupShoppingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public  IQueryable<T> GetAllByRole(string roleEnum, bool tracking = true)
        {
            //var query = _dbContext.Set<T>().AsQueryable();

            //if (!tracking)
            //{
            //    query = query.AsNoTracking();
            //}

            //if (typeof(T) == typeof(AppUser))
            //{
            //    return query.Cast<AppUser>()
            //                 .Where(user => user.UserRoles == roleEnum)
            //                 .Cast<T>();
            //}

            throw new InvalidOperationException("This method can only be used with ApplicationUser entities.");
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

       

        //public IQueryable<T> GetAll(bool tracking = true)
        //{
        //    var query = Table.AsQueryable();
        //    if (!tracking)
        //        query = query.AsNoTracking();
        //    return query;
        //}

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query; ;
        }
    }
}

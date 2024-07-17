using StartupShopping.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Repositories.SessionRepository
{
    public interface ISessionReadRepository:IReadRepository<Session>
    {
        Task<Session> GetByIdAsync(string id);
    }
}

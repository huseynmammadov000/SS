using StartupShopping.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities
{
    public class AppUserRole
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}

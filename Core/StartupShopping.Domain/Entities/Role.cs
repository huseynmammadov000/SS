using StartupShopping.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities
{
    public class Role :BaseEntity
    {
        public Role()
        {
            // Boş yapıcı (constructor) tanımlaması
        }

        public Role(string name)
        {
            Name = name;
        }
        public string Name { get; set; }  // Rolün adı

        public ICollection<AppUserRole> UserRoles { get; set; } 
    }
}

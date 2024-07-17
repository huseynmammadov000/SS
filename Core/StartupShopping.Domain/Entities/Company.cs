using StartupShopping.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities
{
    public class Company :BaseEntity
    {
        public string CompanyName { get; set; }
        
    }
}

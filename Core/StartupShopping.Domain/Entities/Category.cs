using StartupShopping.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities
{
    public class Category :BaseEntity
    {
        public string CategoryName { get; set; } = null!;


    }
}

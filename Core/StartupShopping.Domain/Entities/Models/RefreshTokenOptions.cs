using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities.Models
{
    public sealed class RefreshTokenOptions
    {
        public long ExpireTimeInSecond { get; set; }
    }
}

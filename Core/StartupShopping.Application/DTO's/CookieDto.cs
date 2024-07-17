using StartupShopping.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.DTO_s
{
    public class CookieDto
    {

        public Session Session { get; set; }
        //public RefreshTokenValidation RefreshTokenValidation { get; set; }
        public RefreshTokenValidation RefreshTokenValidation { get; set; }
    }
}

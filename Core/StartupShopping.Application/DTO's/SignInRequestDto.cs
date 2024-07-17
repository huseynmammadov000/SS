using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.DTO_s
{
    public class SignInRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientIpAddress { get; set; }
        public string ClientUserAgent { get; set; }
    }

}

using StartupShopping.Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Commands.AppUser.SignIn
{
    public class SignInCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public string UserId { get; set; }
        public string UserName { get; set; }
        public TokenModel TokenDto { get; set; }
    }
}

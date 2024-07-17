using StartupShopping.Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Commands.AppUser.NewToken
{
    public class NewTokenCommandResponse
    {
        public TokenModel tokenModel {  get; set; }
    }
}

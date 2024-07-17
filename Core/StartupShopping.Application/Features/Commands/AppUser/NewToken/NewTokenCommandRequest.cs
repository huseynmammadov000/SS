using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Commands.AppUser.NewToken
{
    public class NewTokenCommandRequest : IRequest<NewTokenCommandResponse>
    {
        public string refreshToken { get; set; }
    }
}

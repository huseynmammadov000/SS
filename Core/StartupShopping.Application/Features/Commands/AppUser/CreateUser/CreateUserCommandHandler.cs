using MediatR;
using StartupShopping.Application.Abstractions.Identity;
using StartupShopping.Application.DTO_s;
using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserManager _userManager;
        readonly IRoleManager _roleManager;


        public CreateUserCommandHandler(IUserManager userManager, IRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
            {
                role = new Role { Name = request.RoleName };
                var roleResult = await _roleManager.CreateRoleAsync(role.Name);
                if (!roleResult)
                {
                    throw new Exception("Role creation failed");
                }
            }




            TokenDto result = await _userManager.CreateUserAsync(request.UserName,request.Email, request.Password, request.PasswordConfirm,request.RoleName);

            if (result is not null)
            {
                return new CreateUserCommandResponse()
                {
                    Succeeded = true,
                    Message = "Successful",
                    TokenDto = result

                };

            }
            else throw new Exception();


        }
    }
}

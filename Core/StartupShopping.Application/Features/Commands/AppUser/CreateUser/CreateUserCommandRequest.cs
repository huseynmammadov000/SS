using MediatR;
using StartupShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandRequest :IRequest<CreateUserCommandResponse>
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string PasswordConfirm { get; set; } = null!;
        [Required]
        public string RoleName { get; set; }

      
    }
}

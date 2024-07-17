using Microsoft.VisualBasic;
using StartupShopping.Domain.Entities.Common;
using StartupShopping.Domain.Entities.Enum;
using StartupShopping.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities
{
    public class AppUser:BaseEntity
    {

        //public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public Guid RefreshTokenId { get; set; }
        public string? PasswordResetToken { get; set; }
        //public DateTime RefreshTokenExpireDate { get; set; }

        public ICollection<AppUserRole> UserRoles { get; set; }
       
        //public string Role { get; set; } = "User";  // Varsayılan olarak "User" rolü
     
        public Startup? Startup { get; set; }
        public Guid? StartupId { get; set; }
        public Company? Company { get; set; }
        public Portfolio? Portfolio { get; set; }
        public Session? Session { get; set; }
      
        public string? RefreshTokenValidationId { get; set; }
        public RefreshTokenValidation? RefreshTokenValidation { get; set; }

        //public Radar Radar { get; set; }

    }
}

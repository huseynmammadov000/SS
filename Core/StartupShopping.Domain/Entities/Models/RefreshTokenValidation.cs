using StartupShopping.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities.Models
{
    public class RefreshTokenValidation:BaseEntity
    {

        //[Key]
        //public string RefreshTokenValidationId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpiredAt { get; set; }
    }

}

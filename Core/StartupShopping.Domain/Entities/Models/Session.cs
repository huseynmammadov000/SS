using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartupShopping.Domain.Entities.Common;

namespace StartupShopping.Domain.Entities.Models
{

    //[Table(nameof(Session), Schema = IdentityDbContext.Schema)]
    public class Session :BaseEntity
    {
        //[Key]
        //[NotNull]
        //[Column("id")]
        //public string Id { get; set; }

        [Column("userId")]
        public Guid UserId { get; set; }

        [Column("clientRealIp")]
        public string? ClientRealIp { get; set; }

        [Column("clientUserAgent")]
        public string? ClientUserAgent { get; set; }

        [Column("expiredAt")]
        public DateTime ExpiredAt { get; set; }
    }


}

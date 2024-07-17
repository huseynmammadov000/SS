using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities.Models
{
    //[Table(nameof(Token), Schema = IdentityDbContext.Schema)]
    public class Token
    {
        [Key]
        [Column("id")]
        public Guid? Id { get; set; }

        [NotNull]
        [Column("userId")]
        public Guid UserId { get; set; }

        [Column("expiredAt")]
        public DateTime ExpiredAt { get; set; }
    }

}

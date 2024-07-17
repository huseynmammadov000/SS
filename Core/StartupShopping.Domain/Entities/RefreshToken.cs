using StartupShopping.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities
{
    public class RefreshToken :BaseEntity
    {
        //public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid UserId { get; set; }
        public bool IsRevoked { get; set; } = false;

        [JsonIgnore]
        public AppUser User { get; set; }
    }
}

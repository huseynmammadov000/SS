using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.DTO_s
{
    public class SessionDto
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public string? ClientRealIp { get; set; }
        public string? ClientUserAgent { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}

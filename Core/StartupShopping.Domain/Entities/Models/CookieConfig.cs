using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities.Models
{
    public class CookieConfig
    {
        public bool Secure { get; set; }
        public bool HttpOnly { get; set; }
        public bool IsEssential { get; set; }
        public string Path { get; set; }
        public string Domain { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SameSiteMode SameSite { get; set; }
    }

}

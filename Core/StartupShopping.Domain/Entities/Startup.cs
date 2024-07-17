using Microsoft.AspNetCore.Http;
using StartupShopping.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Domain.Entities
{
    public class Startup :BaseEntity
    {
        public string StartupName { get; set; }
        public string StartupDescription { get; set; }
        public string? WebAdress { get; set; }
        public byte[]? Logo { get; set; }
        public DateTime FoundationYear { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public string? PortfolioId { get; set; }
        public Category? Category { get;set; }
        public Guid CategoryId { get; set; }
        public bool active { get; set; }
        public byte[]? UploadedFile { get; set; } // Eklenecek kısım
        public string? UploadedFileName { get; set; }

    }
}

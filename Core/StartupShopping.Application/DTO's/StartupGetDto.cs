using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.DTO_s
{
    public class StartupGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FoundationYear { get; set; }
        public Guid? UserId { get; set; }
        public string CategoryName { get; set; }
        public bool Active { get; set; }
        public string LogoBase64 { get; set; }
        public byte[]? UploadedFile { get; set; } // Eklenecek kısım
        public string? UploadedFileName { get; set; }
    }
}

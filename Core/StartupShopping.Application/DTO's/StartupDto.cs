using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.DTO_s
{
    public class StartupDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime FoundationYear { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public IFormFile? Logo { get; set; } 
        [Required]
        public Guid? UserId { get; set; }
        public byte[]? UploadedFile { get; set; }
        public string? UploadedFileName { get; set; }

    }
}

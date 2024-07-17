using Ardalis.GuardClauses;
using Azure.Core;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using StartupShopping.Application.Abstractions.Auth;
using StartupShopping.Application.DTO_s;
using StartupShopping.Application.Features.Commands.AppUser.CreateUser;
using StartupShopping.Application.Features.Queries.Startup.GetAllStartup;
using StartupShopping.Application.Features.Queries.Startup.GetAllStartupWithCategory;
using StartupShopping.Application.Repositories.AppUserRepository;
using StartupShopping.Application.Repositories.CategoryRepository;
using StartupShopping.Application.Repositories.StartupRepository;
using StartupShopping.Application.RequestParameters;
using StartupShopping.Domain.Entities;
using StartupShopping.Domain.Entities.Enum;
using StartupShopping.Persistance.Repositories.AppUserRepository;
using StartupShoppingAPI.Cookie;
using System.Data;

namespace StartupShoppingAPI.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserReadRepository _appUserReadRepository;
        private readonly IAppUserWriteRepository _appUserWriteRepository;

        private readonly IStartupReadRepository _startupReadRepository;
        private readonly IStartupWriteRepository _startupWriteRepository;

        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IAuthService _authService;


        private readonly ILogger _logger;

        readonly IMediator _mediator;
        public AppUserController(IAppUserReadRepository appUserReadRepository, IAppUserWriteRepository appUserWriteRepository, IStartupReadRepository startupReadRepository, IStartupWriteRepository startupWriteRepository, ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IWebHostEnvironment webHostEnvironment, IMediator mediator, IAuthService authService)
        {
            _appUserReadRepository = appUserReadRepository;
            _appUserWriteRepository = appUserWriteRepository;

            _startupReadRepository = startupReadRepository;
            _startupWriteRepository = startupWriteRepository;

            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;

            _webHostEnvironment = webHostEnvironment;
            _mediator = mediator;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromQuery]CreateUserCommandRequest createUserCommandRequest)
        {
            //CreateCommandUserRequestDto requestDto = createUserCommandRequest.Adapt<CreateCommandUserRequestDto>();

            //string? clientRealIp = Request.Headers.TryGetValue("X-Client-Ip", out StringValues ipAddr)
            //? ipAddr
            //    : Request.HttpContext.Connection.RemoteIpAddress?.ToString();

            //requestDto.ClientIpAddress = Guard.Against.Null(clientRealIp);
            //requestDto.ClientUserAgent = Request.Headers[HeaderNames.UserAgent].ToString();

            //CookieDto signInResponse = await _authService.CreateUserAsync(requestDto);

            //var cookieOptions = new CookieOptions
            //{
            //    Expires = signInResponse.Session.ExpiredAt,
            //    Secure = true,
            //    HttpOnly = true,
            //    IsEssential = true,
            //    Path = "/",
            //    Domain = "localhost",
            //    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict
            //};

            //HttpContext.Response.Cookies.Append(Cookies.SESSION_KEY, (signInResponse.Session.Id).ToString(), cookieOptions);
            //HttpContext.Response.Cookies.Append(Cookies.REFRESHTOKEN_KEY, signInResponse.RefreshTokenValidation.Id.ToString(), cookieOptions);
            ////CreateUserCommandResponse createUserCommandResponse =   await _mediator.Send(createUserCommandRequest);
            //return Ok(signInResponse);
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string id)
        {

            var user = await _appUserReadRepository.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> GetProfile([FromBody]string username)
        {

            var user = await _appUserReadRepository.GetByUserNameAsync(username);
            return Ok(user.Id);
        }


        [HttpGet("Role")]
        public async Task<IActionResult> GetEntrepreneurs(string role)
        {
            var roles = await _appUserReadRepository.GetAllByRole(role, false).ToListAsync();


            return Ok(roles);
        }


        //[HttpGet("Role")]
        //public async Task<IActionResult> GetUserByRole(string UserId)
        //{
        //    var roles = await _appUserReadRepository.GetAllRole(role, false).ToListAsync();


        //    return Ok(roles);
        //}


        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(_appUserReadRepository.GetAll(false));
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _categoryWriteRepository.AddAsync(category);
            await _categoryWriteRepository.SaveAsync();
            return Ok();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateStartup(Startup startup)
        //{
        //    string Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        //    startup.CategoryId = Guid.Parse(Id);
        //    var s = new Startup()
        //    {
        //        StartupName = startup.StartupName,
        //        StartupDescription = startup.StartupDescription,
        //        //s.User.Id = startup.User.Id,
        //        CategoryId = startup.CategoryId,
        //        FoundationYear = startup.FoundationYear,
        //        active = startup.active
        //    };

        //    await _startupWriteRepository.AddAsync(s);
        //    await _startupWriteRepository.SaveAsync();
        //    return Ok("Successful");


        //}
      



        [HttpPost]
        public async Task<ActionResult<Startup>> CreateStartup([FromForm] StartupDto startupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryReadRepository.Table
                                        .FirstOrDefaultAsync(c => c.CategoryName == startupDto.CategoryName);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            byte[] logoData = null;
            if (startupDto.Logo != null)
            {
                logoData = ConvertFormFileToByteArray(startupDto.Logo);
            }
            var user = await _appUserReadRepository.Table.FirstOrDefaultAsync(u => u.Id == startupDto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var startup = new Startup
            {
                StartupName = startupDto.Name,
                StartupDescription = startupDto.Description,
                FoundationYear = startupDto.FoundationYear,
                UserId = (Guid)startupDto.UserId,
                CategoryId = category.Id,
                User = user,
                active = startupDto.Active,
                Logo = logoData,
            };

            //user.Startup = startup;

            await _startupWriteRepository.AddAsync(startup);
            user.StartupId = startup.Id;
            user.Startup = startup;
            await _startupWriteRepository.SaveAsync();

            return Ok("Successful");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StartupGetDto>>> GetAllStartups([FromQuery] Pagination pagination)
        {
            var startups = await _startupReadRepository.GetAll(false)
                .Include(s => s.Category) // Kategori bilgilerini de dahil etmek için
                .ToListAsync();

            var startupDtos = startups.Select(s => new StartupGetDto
            {
                Id = s.Id,
                Name = s.StartupName,
                Description = s.StartupDescription,
                FoundationYear = s.FoundationYear,
                CategoryName = s.Category.CategoryName,
                UserId=s.UserId,
                Active = s.active,
                LogoBase64 = s.Logo != null ? Convert.ToBase64String(s.Logo) : null
            }).ToList();

            return Ok(startupDtos);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Startup>>> GetStartups()
        {
            var startups = await _startupReadRepository.GetAll(false).ToListAsync();
            return Ok(startups);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories =  await _categoryReadRepository.GetAll(false).ToListAsync();
            return Ok(categories);
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        //{
        //    var categories = await _categoryReadRepository.GetAll(false).ToListAsync();
        //    return Ok(categories);
        //}


        [HttpGet]
        public async Task<IActionResult> GetStartup(string id)
        {
            var s = await _startupReadRepository.GetByIdAsync(id);
            return Ok(s);
        }


        [HttpGet]
        public async Task<ActionResult<GetAllStartupQueryResponse>> GetAllStartupsByPage3([FromQuery]GetAllStartupQueryRequest request)
        {
            
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<StartupGetDto>>> GetAllStartupsByPage([FromQuery] Pagination pagination, [FromQuery] string CategoryIds)
        //{
        //    var query = _startupReadRepository.GetAll(false);

        //    if (!string.IsNullOrEmpty(CategoryIds))
        //    {
        //        var categoryIdsArray = new List<Guid>();
        //        var categoryIds = CategoryIds.Split(',');

        //        foreach (var id in categoryIds)
        //        {
        //            if (Guid.TryParse(id, out var guid))
        //            {
        //                categoryIdsArray.Add(guid);
        //            }
        //            else
        //            {
        //                return BadRequest($"Invalid CategoryId: {id}");
        //            }
        //        }

        //        if (categoryIdsArray.Any())
        //        {
        //            query = query.Where(s => categoryIdsArray.Contains(s.CategoryId));
        //        }
        //    }

        //    var totalItems = await query.CountAsync();

        //    var startups = await query
        //        .Include(s => s.Category)
        //        .Skip((pagination.PageNumber - 1) * pagination.PageSize)
        //        .Take(pagination.PageSize)
        //        .ToListAsync();

        //    var startupDtos = startups.Select(s => new StartupGetDto
        //    {
        //        Id = s.Id,
        //        Name = s.StartupName,
        //        Description = s.StartupDescription,
        //        FoundationYear = s.FoundationYear,
        //        CategoryName = s.Category?.CategoryName,
        //        UserId = s.UserId,
        //        Active = s.active,
        //        LogoBase64 = s.Logo != null ? Convert.ToBase64String(s.Logo) : null
        //    }).ToList();

        //    var pagedResult = new PageResult<StartupGetDto>
        //    {
        //        TotalItems = totalItems,
        //        PageNumber = pagination.PageNumber,
        //        PageSize = pagination.PageSize,
        //        TotalPages = (int)Math.Ceiling((double)totalItems / pagination.PageSize),
        //        Items = startupDtos
        //    };

        //    return Ok(pagedResult);
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<StartupGetDto>>> GetAllStartupsByPage([FromQuery] Pagination pagination, [FromQuery] string CategoryIds)
        //{
        //    var query = _startupReadRepository.GetAll(false);

        //    if (!string.IsNullOrEmpty(CategoryIds))
        //    {
        //        var categoryIdsArray = new List<Guid>();
        //        var categoryIds = CategoryIds.Split(',');

        //        foreach (var id in categoryIds)
        //        {
        //            if (Guid.TryParse(id, out var guid))
        //            {
        //                categoryIdsArray.Add(guid);
        //            }
        //            else
        //            {
        //                return BadRequest($"Invalid CategoryId: {id}");
        //            }
        //        }

        //        if (categoryIdsArray.Any())
        //        {
        //            query = query.Where(s => categoryIdsArray.Contains(s.CategoryId));
        //        }
        //    }
        //    else // CategoryIds null veya boş ise
        //    {
        //        // Tüm startup'ları getir
        //        query = query.Where(s => true); // Bu satırı ekleyerek tüm kayıtları döndürebiliriz.
        //    }

        //    var totalItems = await query.CountAsync();

        //    var startups = await query
        //        .Include(s => s.Category)
        //        .Skip((pagination.PageNumber - 1) * pagination.PageSize)
        //        .Take(pagination.PageSize)
        //        .ToListAsync();

        //    var startupDtos = startups.Select(s => new StartupGetDto
        //    {
        //        Id = s.Id,
        //        Name = s.StartupName,
        //        Description = s.StartupDescription,
        //        FoundationYear = s.FoundationYear,
        //        CategoryName = s.Category?.CategoryName,
        //        UserId = s.UserId,
        //        Active = s.active,
        //        LogoBase64 = s.Logo != null ? Convert.ToBase64String(s.Logo) : null
        //    }).ToList();

        //    var pagedResult = new PageResult<StartupGetDto>
        //    {
        //        TotalItems = totalItems,
        //        PageNumber = pagination.PageNumber,
        //        PageSize = pagination.PageSize,
        //        TotalPages = (int)Math.Ceiling((double)totalItems / pagination.PageSize),
        //        Items = startupDtos
        //    };

        //    return Ok(pagedResult);
        //}


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<StartupGetDto>>> GetAllStartupsByPage2([FromQuery] Pagination pagination, [FromQuery] string CategoryIds)
        //{
        //    var query = _startupReadRepository.GetAll(false);

        //    if (!string.IsNullOrEmpty(CategoryIds))
        //    {
        //        var categoryIdsArray = new List<Guid>();
        //        var categoryIds = CategoryIds.Split(',');

        //        foreach (var id in categoryIds)
        //        {
        //            if (Guid.TryParse(id, out var guid))
        //            {
        //                categoryIdsArray.Add(guid);
        //            }
        //            else
        //            {
        //                return BadRequest($"Invalid CategoryId: {id}");
        //            }
        //        }

        //        if (categoryIdsArray.Any())
        //        {
        //            query = query.Where(s => categoryIdsArray.Contains(s.CategoryId));
        //        }
        //    }
        //    else if(CategoryIds.IsNullOrEmpty())
        //    {
        //        var startups2 = await _startupReadRepository.GetAll(false).ToListAsync();
        //        return Ok(startups2);
        //    }

        //    var totalItems = await query.CountAsync();

        //    // Önce kategoriyi include et
        //    var startups = await query
        //        .Include(s => s.Category)  // Burada Include işlemi
        //        .Skip((pagination.PageNumber - 1) * pagination.PageSize)
        //        .Take(pagination.PageSize)
        //        .ToListAsync();

        //    var startupDtos = startups.Select(s => new StartupGetDto
        //    {
        //        Id = s.Id,
        //        Name = s.StartupName,
        //        Description = s.StartupDescription,
        //        FoundationYear = s.FoundationYear,
        //        CategoryName = s.Category.CategoryName,
        //        UserId = s.UserId,
        //        Active = s.active,
        //        LogoBase64 = s.Logo != null ? Convert.ToBase64String(s.Logo) : null
        //    }).ToList();

        //    var response = new PagedResponse<StartupGetDto>
        //    {
        //        Items = startupDtos,
        //        TotalItems = totalItems,
        //        TotalPages = (int)Math.Ceiling((double)totalItems / pagination.PageSize)
        //    };

        //    return Ok(response);
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StartupGetDto>>> GetAllStartupsByPage4([FromQuery] GetAllStartupWithCategoryQueryRequest request)
        {
           
            var response = await _mediator.Send(request);
            return Ok(response);
        }


        //[HttpPost("[action]")]
        //public async Task<IActionResult> Upload()
        //{
        //    string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath,"resource/product-images");

        //    Request.Form.Files
        //}
        [HttpPost("{id}")]
        public async Task<IActionResult> UploadFile(string id, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var startup = await _startupReadRepository.GetByIdAsync(id);
            if (startup == null)
                return NotFound("Startup not found.");

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                startup.UploadedFile = memoryStream.ToArray();
                startup.UploadedFileName = file.FileName;
            }

             _startupWriteRepository.Update(startup);
          await _startupWriteRepository.SaveAsync();

            return Ok(startup);
        }

        //[HttpGet]
        //public async Task<IActionResult> DownloadFile(string id)
        //{
        //    var startup = await _startupReadRepository.GetByIdAsync(id);
        //    if (startup == null || startup.UploadedFile == null)
        //        return NotFound("File not found.");

        //    return File(startup.UploadedFile, "application/octet-stream", startup.UploadedFileName);
        //}
        [HttpGet]
        public async Task<IActionResult> DownloadFile(string id)
        {
            var startup = await _startupReadRepository.GetByIdAsync(id);
            if (startup == null || startup.UploadedFile == null)
                return NotFound("File not found.");

            var contentType = "application/octet-stream"; // Default content type
            var fileExtension = Path.GetExtension(startup.UploadedFileName).ToLowerInvariant();

            // Set the content type based on the file extension
            switch (fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                // Add more cases as needed
                default:
                    break;
            }

            return File(startup.UploadedFile, contentType, startup.UploadedFileName);
        }



        private byte[] ConvertFormFileToByteArray(IFormFile file)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms.ToArray();
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath,"resource/startup-images");

            if(!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            Random r  = new Random();

            foreach (IFormFile file in Request.Form.Files)
            {
                string fullPath = Path.Combine(uploadPath, $"{r.NextDouble()}{Path.GetExtension(file.FileName)}");

                using FileStream fileStream = new(fullPath,FileMode.Create,FileAccess.Write,FileShare.None,1024*1024,useAsync:false);

               await file.CopyToAsync(fileStream);
               await fileStream.FlushAsync();
            }
            return Ok();

        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.DTOS;
using Todo.Domain.Entities.Auth;

namespace Todo.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Authorize(Roles ="TeamLead")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(userDTO.Email))
                throw new Exception("Email required");

            if (string.IsNullOrWhiteSpace(userDTO.UserName))
                throw new Exception("UserName required");

            if (string.IsNullOrWhiteSpace(userDTO.FullName))
                throw new Exception("Fullname required");

            var user = await _userManager.FindByEmailAsync(userDTO.Email);

            if (user is not null)
                throw new Exception("You already registered");

            var file = userDTO.Photo;
            string fileName = "";
            string filePath = "";
            if (file is not null)
            {
                try
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "User", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    using (var PhotoStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(PhotoStream);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("User photo upload error\n", ex);
                }
            }
            var cratedModel = new User()
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                FullName = userDTO.FullName,
                Description = userDTO.Description,
                PhotoPath = "User/" + fileName
            };


            var result = await _userManager.CreateAsync(cratedModel, userDTO.Password);

            if (!result.Succeeded)
                throw new Exception("Something went wrong!");

            
            var role = await _userManager.AddToRoleAsync(cratedModel, userDTO.Role);

            if (!role.Succeeded)
                throw new Exception();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
            {
                user = await _userManager.FindByIdAsync(loginDTO.Email);
            }

            if (user is null)
                throw new Exception("User not found");

            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);

            if (!result.Succeeded)
                throw new Exception("Nuriddin Injection");

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("You are logged out");
        }

    }
}

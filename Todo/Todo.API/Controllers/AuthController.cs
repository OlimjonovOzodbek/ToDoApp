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
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpPost]
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

            var cratedModel = new User()
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                FullName = userDTO.FullName,
                Description = userDTO.Description,
                UserRole = userDTO.UserRole
            };

            var result = await _userManager.CreateAsync(cratedModel, userDTO.Password);

            if (!result.Succeeded)
                throw new Exception("Something went wrong!");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user is null)
                throw new Exception("User not found");

            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);

            if (!result.Succeeded)
                throw new Exception("Nuriddin Injection");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("You are logged out");
        }
    }
}

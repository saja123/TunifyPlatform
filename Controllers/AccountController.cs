using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using TunifyPrj.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountService;
        private readonly IUserRepository _userService;
        private UserManager<ApplicationUser> _userManager;

        public AccountController(IAccount accountService, IUserRepository userService, UserManager<ApplicationUser> userManager)
        {
            _accountService = accountService;
            _userService = userService; 
            _userManager = userManager; 
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerdUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = await _accountService.Register(registerdUserDto, ModelState);

            if (userDto == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(userDto);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = await _accountService.UserAuthentication(loginDto.UserName, loginDto.Password);

            if (userDto == null)
            {
                return Unauthorized("Invalid login attempt");
            }

            return Ok(userDto);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return Ok("Logout successful");
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("AdminGetaUser")]
        public async Task<IActionResult> SomeAdminAction()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
    }
}

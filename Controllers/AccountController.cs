using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models.DTO;
using TunifyPrj.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accountService;

        public AccountController(IAccount accountService)
        {
            _accountService = accountService;
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

            return Ok("User registered successfully");
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

            return Ok("Login successful");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return Ok("Logout successful");
        }
    }
}

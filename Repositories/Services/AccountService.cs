using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using TunifyPrj.Repositories.Interfaces;


namespace Tunify_Platform.Repositories.Services
{
    public class AccountService : IAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserDto> Register(RegisterDto registerdUserDto, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerdUserDto.UserName,
                Email = registerdUserDto.Email,

            };

            var result = await _userManager.CreateAsync(user, registerdUserDto.Password);

            if (result.Succeeded)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerdUserDto) :
                                error.Code.Contains("Email") ? nameof(registerdUserDto) :
                                error.Code.Contains("Username") ? nameof(registerdUserDto) : "";

                modelState.AddModelError(errorCode, error.Description);
            }

            return null;
        }

        public async Task<UserDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }

            return null;
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }


    }
}

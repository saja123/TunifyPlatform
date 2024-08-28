using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;


namespace TunifyPrj.Repositories.Interfaces
{
    public interface IAccount
    {
        // Add register
        public Task<UserDto> Register(RegisterDto registerdAccountDto, ModelStateDictionary modelState);

        // Add login 
        public Task<UserDto> UserAuthentication(string username, string password);
        public Task Logout();

        Task<string> GenerateJwtToken(ApplicationUser user, IList<string> roles);
    }
}

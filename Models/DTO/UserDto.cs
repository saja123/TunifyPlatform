using Microsoft.AspNetCore.Identity;


namespace Tunify_Platform.Models.DTO
{
    public class UserDto : IdentityUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        }
    }
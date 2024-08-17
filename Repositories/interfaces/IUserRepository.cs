using Tunify_Platform.Models;

namespace Tunify_Platform
{
    public interface IUserRepository
    {
        Task<User> createUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<User> UpdateUserById(int id, User user);
        Task DeleteUserById(int id);//beacuse not have retain informations



    }
}
using Microsoft.EntityFrameworkCore;
using Tunify_Platform;
using Tunify_Platform.Models;

namespace Tunify_Platform
{
    public class UserService : IUserRepository
    {
        private readonly TunifyDbContext _context;
        private readonly object updatedUser;
        private object UpdatedUserById;

        public UserService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<User> createUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserById(int id)
        {
            var deleteuser = await GetUserById(id);
            _context.Users.Remove(deleteuser);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var allusers = await _context.Users.ToListAsync();
            return allusers;
        }

        public async Task<User> GetUserById(int userId)
        {
            var alluser = await _context.Users.FindAsync(userId);
            return alluser;
        }

        public async Task<User> UpdateUserById(int id, User updatedUser)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser != null)
            {
                existingUser.Username = updatedUser.Username;
                existingUser.Email = updatedUser.Email;
                existingUser.JoinDate = updatedUser.JoinDate;
                existingUser.SubscriptionId = updatedUser.SubscriptionId;
                existingUser.Subscriptions = updatedUser.Subscriptions;
                existingUser.Playlists = updatedUser.Playlists;

                await _context.SaveChangesAsync();
            }
            return existingUser;
        }

    }
}

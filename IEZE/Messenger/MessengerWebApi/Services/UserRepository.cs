using Messenger.Persistence.Entities;
using Messenger.Persistence.Models;
using MessengerWebApi.DTO;
using MessengerWebApi.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MessengerWebApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly MessengerContext _context;
        public UserRepository(MessengerContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetSingleUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return null;

            return user;
        }
        public async Task<List<User>> AddUser(UserDto userInput)
        {
            var user = new User
            {
                Username = userInput.Username,
                PasswordHash = userInput.PasswordHash,
                PasswordSalt = userInput.PasswordSalt,
                CreatedAt = userInput.CreatedAt,
                ModifiedAt = userInput.ModifiedAt,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }
        public async Task<List<User>?> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }
    }
}

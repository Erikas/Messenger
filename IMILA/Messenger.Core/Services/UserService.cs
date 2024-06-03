using Messenger.Core.Models;
using Messenger.Persistence.Context;
using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(long id);
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<bool> UpdateUserAsync(long id, CreateUserDto createUserDto);
        Task<bool> DeleteUserAsync(long id);
    }

    public class UserService : IUserService
    {
        private readonly MessengerDbContext _context;

        public UserService(MessengerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PictureBlobUrl = user.PictureBlobUrl,
                Country = user.Country,
                CreationTS = user.CreationTS,
                ModificationTS = user.ModificationTS
            }).ToList();
        }

        public async Task<UserDto?> GetUserByIdAsync(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PictureBlobUrl = user.PictureBlobUrl,
                Country = user.Country,
                CreationTS = user.CreationTS,
                ModificationTS = user.ModificationTS
            };
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber,
                PictureBlobUrl = createUserDto.PictureBlobUrl,
                Country = createUserDto.Country,
                CreationTS = DateTime.UtcNow,
                ModificationTS = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PictureBlobUrl = user.PictureBlobUrl,
                Country = user.Country,
                CreationTS = user.CreationTS,
                ModificationTS = user.ModificationTS
            };
        }

        public async Task<bool> UpdateUserAsync(long id, CreateUserDto createUserDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            user.FirstName = createUserDto.FirstName;
            user.LastName = createUserDto.LastName;
            user.Email = createUserDto.Email;
            user.PhoneNumber = createUserDto.PhoneNumber;
            user.PictureBlobUrl = createUserDto.PictureBlobUrl;
            user.Country = createUserDto.Country;
            user.ModificationTS = DateTime.UtcNow;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

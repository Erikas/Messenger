using Messenger.Persistence.Entities;
using MessengerWebApi.DTO;

namespace MessengerWebApi.Services.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetSingleUser(int id);
        Task<List<User>> AddUser(UserDto userInput);
        Task<List<User>?> DeleteUser(int id);
    }
}

using Microsoft.AspNetCore.Mvc;
using MessengerWebApi.Services.Contracts;
using Messenger.Persistence.Entities;
using MessengerWebApi.DTO;

namespace MessengerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetSingleUser(int id)
        {
            var result = await _userRepository.GetSingleUser(id);
            if (result == null)
                return NotFound("User not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(UserDto userInput)
        {
            var result = await _userRepository.AddUser(userInput);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteUser(id);
            if (result == null)
                return NotFound("User not found");

            return Ok(result);
        }
    }
}

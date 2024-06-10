using Messenger.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string userName)
        {
            var user = await userService.CreateUserAsync(userName);

            return Created(nameof(Post), user);
        }
    }
}
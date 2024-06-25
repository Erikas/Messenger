using Messenger.API.ApplicationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Messenger.API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserApplicationService userApplicationService;

        public UsersController(IUserApplicationService userApplicationService)
        {
            this.userApplicationService = userApplicationService;
        }

        [HttpPost]
        [ProducesResponseType<int>(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Post(string userName)
        {
            var user = await userApplicationService.Create(userName);

            return Created(nameof(Post), user);
        }
    }
}
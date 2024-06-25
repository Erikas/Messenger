using Messenger.API.ApplicationServices;
using Messenger.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Messenger.API.Controllers
{
    public class MessagesController : BaseController
    {
        private readonly IMessageApplicationService messageApplicationService;

        public MessagesController(IMessageApplicationService messageApplicationService)
        {
            this.messageApplicationService = messageApplicationService;
        }

        [HttpPost]
        [ProducesResponseType<int>(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Post([FromBody] NewMessageModel model) 
        {
            var id = await messageApplicationService.Create(model);
            return Created(nameof(Post), id);
        }
    }
}
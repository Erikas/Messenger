using Messenger.API.Models;
using Messenger.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessagesController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewMessageModel model) 
        {
            await messageService.Create(model);

            return Ok();
        }
    }
}
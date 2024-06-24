using Messenger.API.ApplicationServices;
using Messenger.API.Models.Chat;
using Messenger.Core.Models;
using Messenger.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Messenger.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService chatService;
        private readonly IChatApplicationService chatApplicationService;

        public ChatsController(IChatService chatService,
        IChatApplicationService chatApplicationService)
        {
            this.chatService = chatService;
            this.chatApplicationService = chatApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> PostSoloChat([FromBody] SinglePersonChatCreationModel model)
        {
            var result = await chatService.CreateSoloChat(model);
            return Created(nameof(PostSoloChat), result);
        }

        [HttpGet("{id:int}/Messages")]
        [ProducesResponseType<ActionResult<IMessageModel>>(StatusCodes.Status200OK)]
        public async Task<ActionResult<IMessageModel>> GetMessages([FromRoute] int id,
        [FromQuery] int? rows)
        {
            var result = await chatApplicationService.GetChatMessages(id, rows);
            return Ok(result);
        }
    }
}
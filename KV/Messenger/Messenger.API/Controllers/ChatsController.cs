using Messenger.API.ApplicationServices;
using Messenger.API.Models.Chat;
using Messenger.Core.Models.ChatModels;
using Messenger.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [Route("api/[controller]")]
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
        [ProducesResponseType<ActionResult<IChatMessageModel>>(StatusCodes.Status200OK)]
        public async Task<ActionResult<IChatMessageModel>> GetMessages([FromRoute] int id,
        [FromQuery] int? rows)
        {
            var result = await chatApplicationService.GetChatMessages(id, rows);
            return Ok(result);
        }
    }
}
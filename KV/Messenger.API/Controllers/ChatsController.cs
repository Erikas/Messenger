using Messenger.API.Models.Chat;
using Messenger.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService chatService;

        public ChatsController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> PostSoloChat([FromBody] SinglePersonChatCreationModel model)
        {
            var result = await chatService.CreateSoloChat(model);
            return Created(nameof(PostSoloChat), result);
        }
    }
}
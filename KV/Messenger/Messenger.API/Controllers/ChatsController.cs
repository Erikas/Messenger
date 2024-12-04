using Messenger.API.ApplicationServices;
using Messenger.API.Models.Chat;
using Messenger.Core.Models;
using Messenger.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Messenger.API.Controllers.Chat;

namespace Messenger.API.Controllers
{
    public class ChatsController : ChatBaseController
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
    }
}
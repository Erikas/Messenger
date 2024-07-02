using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers.Chat
{
    [Route("Chats/{chatId:int}/[controller]")]
    public abstract class ChatBaseController : BaseController
    {
        public ChatBaseController()
        {
        }
    }
}
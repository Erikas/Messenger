using Messenger.Core.Models;
using Messenger.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.API.ApplicationServices
{
    public interface IChatApplicationService
    {
        
    }

    internal class ChatApplicationService : IChatApplicationService
    {
        private readonly IChatService chatService;

        public ChatApplicationService(IChatService chatService)
        {
            this.chatService = chatService;
        }
    }
}
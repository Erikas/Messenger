using Messenger.Core.Models.ChatModels;
using Messenger.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Messenger.API.ApplicationServices
{
    public interface IChatApplicationService
    {
        Task<IEnumerable<IChatMessageModel>> GetChatMessages(int id, int? rows);
    }

    internal class ChatApplicationService : IChatApplicationService
    {
        private readonly IChatService chatService;

        public ChatApplicationService(IChatService chatService)
        {
            this.chatService = chatService;
        }

        public async Task<IEnumerable<IChatMessageModel>> GetChatMessages(int id, int? rows)
        {
            var query = chatService.QueryChatMessages(id);

            int take = rows ?? 10;

            return await query.Take(take).ToListAsync();
        }
    }
}
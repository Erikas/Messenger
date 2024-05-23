using AutoMapper;
using Messenger.Core.Models.ChatModels;
using Messenger.Core.Resources;
using Messenger.Data;
using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Messenger.Core.Services
{
    public interface IChatService
    {
        Task<IChatDtoModel> CreateSoloChat(ISinglePersonChatCreationModel model);
    }

    internal class ChatService : IChatService
    {
        private readonly MessengerContext messengerContext;
        private readonly IMapper mapper;
        
        public ChatService(MessengerContext messengerContext, IMapper mapper)
        {
            this.messengerContext = messengerContext;
            this.mapper = mapper;
        }

        public async Task<IChatDtoModel> CreateSoloChat(ISinglePersonChatCreationModel model)
        {
            var newChat = new Chat
            {
                Name = model.Name ?? LocalNames.NewChatName,
                ChangeTS = DateTime.Now
            };

            await messengerContext.Chats.AddAsync(newChat);
            
            var currentUser = await messengerContext.Users.FindAsync(model.UserId);

            newChat.Participants = [
                new Participant{
                    IsAdmin = true,
                    IsCreator = true,
                    ChatId = newChat.Id,
                    Chat = newChat,
                    UserId = model.UserId,
                    User = currentUser ?? throw new InvalidOperationException(),
                    ChangeTS = DateTime.Now
                }
                ];

            await messengerContext.SaveChangesAsync();

            return mapper.Map<IChatDtoModel>(newChat);
        }
    }
}
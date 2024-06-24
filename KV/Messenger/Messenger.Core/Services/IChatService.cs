using AutoMapper;
using Messenger.Core.Infrastructure;
using Messenger.Core.Models;
using Messenger.Core.Models.ChatModels;
using Messenger.Database.Entities;
using Messenger.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Messenger.Core.Services
{
    public interface IChatService
    {
        Task<IChatDtoModel> CreateSoloChat(ISinglePersonChatCreationModel model);
        IQueryable<IMessageModel> QueryChatMessages(int chatId);
    }

    internal class ChatService : IChatService
    {
        private readonly MessengerContext messengerContext;
        private readonly IVerificationService verificationService;
        private readonly IMapper mapper;
        
        public ChatService(MessengerContext messengerContext,
            IVerificationService verificationService,
            IMapper mapper)
        {
            this.messengerContext = messengerContext;
            this.verificationService = verificationService;
            this.mapper = mapper;
        }

        public async Task<IChatDtoModel> CreateSoloChat(ISinglePersonChatCreationModel model)
        {
            var newChat = new Chat
            {
                Name = model.Name ?? Constants.ChatValues.NewChatName,
                ChangeTS = DateTime.Now
            };

            await messengerContext.Chats.AddAsync(newChat);
            
            var currentUser = await messengerContext.Users.FindAsync(model.UserId)
                ?? throw new InvalidOperationException();

            newChat.Participants = [
                new Participant{
                    IsAdmin = true,
                    IsCreator = true,
                    IsActive = true,
                    ChatId = newChat.Id,
                    Chat = newChat,
                    UserId = model.UserId,
                    User = currentUser,
                    ChangeTS = DateTime.Now
                }
                ];

            await messengerContext.SaveChangesAsync();

            return mapper.Map<IChatDtoModel>(newChat);
        }

        public IQueryable<IMessageModel> QueryChatMessages(int chatId)
        {
            var result =
                from msg in messengerContext.Messages
                join prt in messengerContext.Participants
                    on msg.SenderParticipantId equals prt.Id
                join usr in messengerContext.Users
                    on prt.UserId equals usr.Id
                where msg.ChatId == chatId
                select new MessageModel
                {
                    Id = msg.Id,
                    Content = msg.Content,
                    SenderName = prt.NickName ?? usr.Name,
                    ChangeTS = msg.ChangeTS
                };

            return result.OrderByDescending(x => x.ChangeTS);
        }
    }
}
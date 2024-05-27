using AutoMapper;
using Messenger.Core.Models.ChatModels;
using Messenger.Core.Resources;
using Messenger.Data;
using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Messenger.Core.Services
{
    public interface IChatService
    {
        Task<IChatDtoModel> CreateSoloChat(ISinglePersonChatCreationModel model);
        Task CreateChatParticipant(INewParticipantModel model, int currentUser);
        IQueryable<IChatMessageModel> QueryChatMessages(int chatId);
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

        public async Task CreateChatParticipant(INewParticipantModel model, int currentUser)
        {
            await verificationService.VerifyIfUserIsChatAdmin(currentUser, model.ChatId);
            await verificationService.VerifyIfUserIsNotAlreadyInTheChat(model.UserId, model.ChatId);

            var newParticipant = new Participant
            {
                IsAdmin = model.IsAdmin ?? false,
                IsCreator = model.IsCreator ?? false,
                ChatId = model.ChatId,
                UserId = model.UserId,
                ChangeTS = DateTime.Now,
                Chat = await CurrentChat(model.ChatId),
                User = await CurrentUser(model.UserId)
            };

            await messengerContext.Participants.AddAsync(newParticipant);
            await messengerContext.SaveChangesAsync();

            return;
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

        public IQueryable<IChatMessageModel> QueryChatMessages(int chatId)
        {
            var result = messengerContext.Messages
                .Include(msg => msg.Chat)
                .Include(msg => msg.SenderParticipant).ThenInclude(prt => prt.User)
                .OrderByDescending(msg => msg.ChangeTS).ThenByDescending(msg => msg.Id)
                .Where(msg => msg.ChatId == chatId)
                .Select(msg => new ChatMessageModel
                {
                    Id = msg.Id,
                    Content = msg.Content,
                    SenderName = msg.SenderParticipant.NickName ?? msg.SenderParticipant.User.Name,
                    ChangeTS = msg.ChangeTS
                })
                .AsQueryable();

            return result;
        }

        private async Task<Chat> CurrentChat(int id)
        {
            return await messengerContext.Chats.FirstAsync(x => x.Id == id);
        }

        private async Task<User> CurrentUser(int id)
        {
            return await messengerContext.Users.FirstAsync(x => x.Id == id);
        }
    }
}
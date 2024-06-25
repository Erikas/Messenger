using Messenger.Core.Models;
using Messenger.Database;
using Messenger.Database.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messenger.Core.Services
{
    public interface IMessageService
    {
        Task<int> Create(INewMessageModel model);
    }

    internal class MessageService : IMessageService
    {
        private readonly MessengerContext messengerContext;

        public MessageService(MessengerContext messengerContext)
        {
            this.messengerContext = messengerContext;
        }

        public async Task<int> Create(INewMessageModel model)
        {
            
            var sender = await GetParticipant(model.SenderId);
            var chat = await GetChat(model.ChatId);
            var newMessage = new Message
            {
                Content = model.Content,
                ChatId = model.ChatId,
                Chat = chat,
                SenderParticipantId = sender.Id,
                SenderParticipant = sender,
                ChangeTS = DateTime.Now,
            };

            await messengerContext.Messages.AddAsync(newMessage);
            await messengerContext.SaveChangesAsync();
            return newMessage.Id;
        }

        private async Task<Participant> GetParticipant(int id)
        {
            return await messengerContext.Participants.FindAsync(id) 
                ?? throw new KeyNotFoundException();
        }

        private async Task<Chat> GetChat(int id)
        {
            return await messengerContext.Chats.FindAsync(id) 
                ?? throw new KeyNotFoundException();
        }
    }
}
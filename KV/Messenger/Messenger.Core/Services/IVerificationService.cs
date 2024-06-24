using Messenger.Core.Infrastructure.Exceptions;
using Messenger.Core.Infrastructure;
using Messenger.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Core.Services
{
    public interface IVerificationService
    {
        Task VerifyIfUserIsChatAdmin(int userId, int chatId);
        Task VerifyIfUserIsNotAlreadyInTheChat(int newUserId, int chatId);
        Task<bool> ParticipantIsAdminStatus(int id);
    }

    internal class VerificationService : IVerificationService
    {
        private readonly MessengerContext messengerContext;

        public VerificationService(MessengerContext messengerContext)
        {
            this.messengerContext = messengerContext;
        }

        public async Task<bool> ParticipantIsAdminStatus(int id)
        {
            return await messengerContext.Participants.AnyAsync(x => x.Id == id && x.IsAdmin);
        }

        public async Task VerifyIfUserIsChatAdmin(int userId, int chatId)
        {
            var result = await messengerContext.Chats
                .AnyAsync(x => x.Id == chatId &&
                    x.Participants != null && 
                    x.Participants.Any(x => x.UserId == userId && x.IsAdmin));

            if (result) { return; }

            throw new UnauthorizedException(ExceptionMessages.Unauthorized);
        }

        public async Task VerifyIfUserIsNotAlreadyInTheChat(int newUserId, int chatId)
        {
            var result = await messengerContext.Participants
                .AnyAsync(x => x.UserId == newUserId &&
                    x.ChatId == chatId);

            if (!result)
            {
                return;
            }

            throw new NotImplementedException(); // Handle this w/ custom exception
        }
    }
}
﻿using Messenger.Core.Exceptions;
using Messenger.Core.Resources;
using Messenger.Data;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Core.Services
{
    public interface IVerificationService
    {
        Task VerifyIfUserIsChatAdmin(int userId, int chatId);
        Task VerifyIfUserIsNotAlreadyInTheChat(int newUserId, int chatId);
    }

    internal class VerificationService : IVerificationService
    {
        private readonly MessengerContext messengerContext;

        public VerificationService(MessengerContext messengerContext)
        {
            this.messengerContext = messengerContext;
        }

        public async Task VerifyIfUserIsChatAdmin(int userId, int chatId)
        {
            var result = await messengerContext.Chats
                .AnyAsync(x => x.Id == chatId &&
                    x.Participants != null && 
                    x.Participants.Any(x => x.UserId == userId && x.IsAdmin));

            if (result) { return; }

            throw new UnauthorizedException(ExceptionMessages.UnauthorizedMessage);
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
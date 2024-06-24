using Messenger.Core.Models;
using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Messenger.Core.Infrastructure;
using Messenger.Database;


namespace Messenger.Core.Services
{
    public interface IParticipantService
    {
        Task Remove(int id, int currentId);       
        Task<int> Create(INewParticipantModel model);
        IQueryable<IParticipantDtoModel> Get(int chadId);
    }

    internal class ParticipantService : IParticipantService
    {
        private readonly MessengerContext messengerContext;
        private readonly IVerificationService verificationService;

        public ParticipantService(MessengerContext messengerContext,
            IVerificationService verificationService)
        {
            this.messengerContext = messengerContext;
            this.verificationService = verificationService;
        }

        public async Task<int> Create(INewParticipantModel model)
        {
            await verificationService.VerifyIfUserIsChatAdmin(model.RequestUserId, model.ChatId);
            await verificationService.VerifyIfUserIsNotAlreadyInTheChat(model.UserId, model.ChatId);
            var chat = await messengerContext.Chats.FindAsync(model.ChatId)
                ?? throw new KeyNotFoundException();
            var user = await messengerContext.Users.FindAsync(model.UserId)
                ?? throw new KeyNotFoundException();


            var newParticipant = new Participant
            {
                NickName = model.NickName,
                IsAdmin = model.IsAdmin ?? false,
                IsCreator = model.IsCreator ?? false,
                IsActive = true,
                ChatId = model.ChatId,
                UserId = model.UserId,
                ChangeTS = DateTime.Now,
                Chat = chat,
                User = user,
            };

            await messengerContext.Participants.AddAsync(newParticipant);
            await messengerContext.SaveChangesAsync();

            return newParticipant.Id;
        }

        public async Task Remove(int participantToRemoveId, int requestorParticipantId)
        {
            if (participantToRemoveId == requestorParticipantId)
            {
                var currentParticipant = await messengerContext.Participants.FindAsync(requestorParticipantId)
                    ?? throw new KeyNotFoundException();

                currentParticipant.IsActive = false;
                currentParticipant.ChangeTS = DateTime.Now;
                messengerContext.Participants.Update(currentParticipant);
                await messengerContext.SaveChangesAsync();

                return;
            }
           
            if (await verificationService.ParticipantIsAdminStatus(participantToRemoveId))
            {
                throw new UnauthorizedAccessException(ExceptionMessages.CannotDeleteAdmin);
            }

            if (!await verificationService.ParticipantIsAdminStatus(requestorParticipantId))
            {
                throw new UnauthorizedAccessException(ExceptionMessages.Unauthorized);
            }

            var participant = await messengerContext.Participants.FindAsync(participantToRemoveId)
                    ?? throw new KeyNotFoundException();

            participant.IsActive = false;
            participant.ChangeTS = DateTime.Now;
            messengerContext.Participants.Update(participant);
            await messengerContext.SaveChangesAsync();
            return;
        }

        public IQueryable<IParticipantDtoModel> Get(int chadId)
        {
            var result = messengerContext.Participants
                .Where(x => x.ChatId == chadId)
                .Include(x => x.User)
                .Select(x => new ParticipantDtoModel
                {
                    Id = x.Id,
                    Name = x.NickName ?? x.User.Name,
                    IsActive = x.IsActive,
                    IsAdmin = x.IsAdmin,
                    IsCreator = x.IsCreator
                });

            return result;                
        }
    }
}
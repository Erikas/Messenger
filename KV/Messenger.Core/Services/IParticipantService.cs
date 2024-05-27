using Messenger.Core.Resources;
using Messenger.Data;

namespace Messenger.Core.Services
{
    public interface IParticipantService
    {
        Task Remove(int participantId, int currentParticipantId);
    }

    public class ParticipantService : IParticipantService
    {
        private readonly MessengerContext messengerContext;
        private readonly IVerificationService verificationService;

        public ParticipantService(MessengerContext messengerContext, IVerificationService verificationService)
        {
            this.messengerContext = messengerContext;
            this.verificationService = verificationService;
        }

        public async Task Remove(int participantId, int currentParticipantId)
        {
            if (participantId == currentParticipantId)
            {
                var currentParticipant = await messengerContext.Participants.FindAsync(currentParticipantId)
                    ?? throw new KeyNotFoundException();

                currentParticipant.IsActive = false;
                messengerContext.Participants.Update(currentParticipant);
                await messengerContext.SaveChangesAsync();

                return;
            }

            
            if (await verificationService.ParticipantIsAdminStatus(participantId))
            {
                throw new UnauthorizedAccessException(ExceptionMessages.CannotDeleteAdmin);
            }

            if (!await verificationService.ParticipantIsAdminStatus(currentParticipantId))
            {
                throw new UnauthorizedAccessException(ExceptionMessages.Unauthorized);
            }

            var participant = await messengerContext.Participants.FindAsync(participantId)
                    ?? throw new KeyNotFoundException();

            participant.IsActive = false;
            messengerContext.Participants.Update(participant);
            await messengerContext.SaveChangesAsync();
            return;
        }
    }
}
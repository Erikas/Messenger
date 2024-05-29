using AutoMapper;
using Messenger.API.Models;
using Messenger.Core.Models.ChatModels;
using Messenger.Core.Services;

namespace Messenger.API.ApplicationServices
{
    public interface IParticipantApplicationService
    {
        Task<int> Create(ParticipantCreationModel model, int chatId);
    }

    internal class ParticipantApplicationService : IParticipantApplicationService
    {
        private readonly IParticipantService participantService;
        private readonly IMapper mapper;

        public ParticipantApplicationService(IParticipantService participantService,
            IMapper mapper)
        {
            this.participantService = participantService;
            this.mapper = mapper;
        }

        public async Task<int> Create(ParticipantCreationModel model, int chatId)
        {

            var creationModel = mapper.Map<INewParticipantModel>(model);
            creationModel.ChatId = chatId;
            
            return await participantService.Create(creationModel);
        }
    }
}
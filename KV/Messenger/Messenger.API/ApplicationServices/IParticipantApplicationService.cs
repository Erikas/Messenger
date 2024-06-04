using AutoMapper;
using AutoMapper.QueryableExtensions;
using Messenger.API.Models;
using Messenger.Core.Models;
using Messenger.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Messenger.API.ApplicationServices
{
    public interface IParticipantApplicationService
    {
        Task<int> Create(ParticipantCreationModel model, int chatId);
        Task<IEnumerable<ParticipantModel>> Get(int chatId);

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

        public async Task<IEnumerable<ParticipantModel>> Get(int chatId)
        {
            // TODO: Add authorization restrictions
            var query = participantService.Get(chatId);
            return await query.ProjectTo<ParticipantModel>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
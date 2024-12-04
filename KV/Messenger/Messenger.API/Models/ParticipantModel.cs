using AutoMapper;
using Messenger.Core.Models;

namespace Messenger.API.Models
{
    public class ParticipantModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCreator { get; set; }
        public bool IsActive { get; set; }
    }

    internal class ParticipantModelProfile : Profile
    {
        public ParticipantModelProfile()
        {
            CreateProjection<IParticipantDtoModel, ParticipantModel>();
        }
    }
}
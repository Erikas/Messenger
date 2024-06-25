using AutoMapper;
using Messenger.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Messenger.API.Models
{
    public class ParticipantCreationModel
    {
        [StringLength(50)]
        public string? NickName { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsCreator { get; set; }
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
        [Range(1, int.MaxValue)]
        public int RequestUserId { get; set; }
    }

    public class ParticipantCreationModelProfile : Profile
    {
        public ParticipantCreationModelProfile()
        {
            CreateMap<ParticipantCreationModel, INewParticipantModel>().AsProxy();
        }
    }
}
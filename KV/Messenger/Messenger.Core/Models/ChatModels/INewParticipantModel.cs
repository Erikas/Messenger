using AutoMapper;
using Messenger.Data.Entities;

namespace Messenger.Core.Models.ChatModels
{
    public interface INewParticipantModel
    {
        bool? IsAdmin { get; set; }
        bool? IsCreator { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
    }
}
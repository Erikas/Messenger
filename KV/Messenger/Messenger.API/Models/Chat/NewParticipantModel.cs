using Messenger.Core.Models.ChatModels;

namespace Messenger.API.Models.Chat
{
    public class NewParticipantModel : INewParticipantModel
    {
        public bool? IsAdmin  { get; set; }
        public bool? IsCreator  { get; set; }
        public int ChatId { get; set; }
        public int UserId  { get; set; }
    }
}
using Messenger.Core.Models.ChatModels;

namespace Messenger.API.Models.Chat
{
    public class SinglePersonChatCreationModel : ISinglePersonChatCreationModel
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
    }
}
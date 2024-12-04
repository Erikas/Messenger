namespace Messenger.Core.Models.ChatModels
{
    public interface ISinglePersonChatCreationModel
    {
        int UserId { get; set; }
        string? Name { get; set; }
    }
}
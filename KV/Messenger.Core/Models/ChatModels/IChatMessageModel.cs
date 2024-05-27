namespace Messenger.Core.Models.ChatModels
{
    public interface IChatMessageModel
    {
        int Id { get; set; }
        string Content { get; set; }
        string SenderName { get; set; }
        DateTime ChangeTS { get; set; }
    }

    internal class ChatMessageModel : IChatMessageModel
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public required string SenderName { get; set; }
        public DateTime ChangeTS { get; set; }
    }
}
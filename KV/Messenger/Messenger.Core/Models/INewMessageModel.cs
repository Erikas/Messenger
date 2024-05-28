namespace Messenger.Core.Models
{
    public interface INewMessageModel
    {
        string Content { get; set; }
        int ChatId { get; set; }
        int SenderId { get; set; }
    }
}
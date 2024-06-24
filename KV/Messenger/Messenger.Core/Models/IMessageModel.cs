using System;

namespace Messenger.Core.Models
{
    public interface IMessageModel
    {
        int Id { get; set; }
        string Content { get; set; }
        string SenderName { get; set; }
        DateTime ChangeTS { get; set; }
    }

    internal class MessageModel : IMessageModel
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public required string SenderName { get; set; }
        public DateTime ChangeTS { get; set; }
    }
}
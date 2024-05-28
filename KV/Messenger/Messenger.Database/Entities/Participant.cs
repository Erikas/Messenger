namespace Messenger.Data.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string? NickName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCreator { get; set; }
        public bool IsActive { get; set; }
        public int ChatId { get; set; }
        public required Chat Chat { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public ICollection<Message>? SentMessages { get; set; }
        public DateTime ChangeTS { get; set; }
    }
}
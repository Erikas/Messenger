namespace Messenger.Persistence.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<MessageAttachment> MessageAttachment { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<ChatThread> ChatThread { get; set; }
        public virtual ICollection<ThreadParticipant> ThreadParticipant { get; set; }
        public virtual ICollection<Friendship> FriendshipUser1 { get; set; }
        public virtual ICollection<Friendship> FriendshipUser2 { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual UserSettings UserSettings { get; set; }
        public virtual UserStatus UserStatus { get; set; }

    }
}

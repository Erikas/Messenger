using System.Collections.Generic;

namespace Messenger.Database.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserFriendId { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<User> UserFriends { get; set; }
    }
}

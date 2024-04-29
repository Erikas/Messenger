﻿namespace Messenger.Persistence.Entities
{
    public class Friendship
    {
        public int Id { get; set; }
        public int FriendsUserID1 { get; set; }
        public int FriendsUserID2 { get; set; }
        public DateTime FriendshipStartDate { get; set; }
        public string FriendshipStatus { get; set; }

        public virtual User FriendId1 { get; set; }
        public virtual User FriendId2 { get; set; }

    }
}

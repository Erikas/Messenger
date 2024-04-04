using System;

namespace Messenger.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PictureUrl { get; set; }
        public DateTime AccountCreationDaten { get; set; }
        public UserSettings UserSettings { get; set; }
        public Friend Friend { get; set; }
        public Message Message { get; set; }
        public ThredParticipants ThredParticipants { get; set; }
    }
}

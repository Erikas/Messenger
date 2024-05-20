using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Data.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string? NickName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCreator { get; set; }
        public int ChatId { get; set; }
        public required Chat Chat { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public ICollection<Message>? Messages { get; set; }
        public DateTime ChangeTS { get; set; }
    }
}

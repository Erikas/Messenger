using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Database.Entities
{
    public class ThredParticipants
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ThredId { get; set; }
        public ICollection<Thred> Threds { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

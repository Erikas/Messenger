using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public int ChatId { get; set; }
        public required Chat Chat { get; set; }
    }
}
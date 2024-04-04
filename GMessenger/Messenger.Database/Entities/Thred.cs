using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Database.Entities
{
    public class Thred
    {
        public int Id { get; set; }
        public string ChatName { get; set;}
        public bool IsGroupChat { get; set;}
        public Message Messages { get; set;}
        public ThredParticipants ThredParticipants { get; set;}
    }
}

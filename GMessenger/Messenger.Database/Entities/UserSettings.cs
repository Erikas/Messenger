using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Database.Entities
{
    public class UserSettings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Theme { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastTimeActive { get; set; }
        public User User { get; set; }
    }
}

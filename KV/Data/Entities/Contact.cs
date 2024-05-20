using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Data.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public int ContactBookId {  get; set; }
        public required ContactBook ContactBook { get; set; }
        public int ContactUserId { get; set; }
        public required User ContactUser { get; set; }
        public DateTime ChangeTS { get; set; }
    }
}
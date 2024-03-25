using System.ComponentModel.DataAnnotations;

namespace Messenger.Domain
{
    public class Threads
    {

        [Key]
        public long ThreadId { get; set; }
        public required string ThreadName { get; set; }
        public required List<UserAccount> CreationUserAccountId { get; set; }
        public required bool IsGroup { get; set; }
    }
}

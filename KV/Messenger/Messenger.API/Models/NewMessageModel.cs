using Messenger.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Messenger.API.Models
{
    public class NewMessageModel : INewMessageModel
    {
        [StringLength(2000)]
        public required string Content {  get; set; }
        public int ChatId {  get; set; }
        public int SenderId { get; set; }
    }                                  
}
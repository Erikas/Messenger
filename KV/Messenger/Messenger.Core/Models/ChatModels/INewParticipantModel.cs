namespace Messenger.Core.Models.ChatModels
{
    public interface INewParticipantModel
    {
        string? NickName { get; set; }
        bool? IsAdmin { get; set; }
        bool? IsCreator { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public int RequestUserId { get; set; }
    }
}
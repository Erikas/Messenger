namespace Messenger.Core.Models
{
    public interface IParticipantDtoModel
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsAdmin { get; set; }
        bool IsCreator { get; set; }
        bool IsActive { get; set; }
    }

    internal class ParticipantDtoModel : IParticipantDtoModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCreator { get; set; }
        public bool IsActive { get; set; }
    }
}
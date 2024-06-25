using AutoMapper;
using Messenger.Core.Infrastructure;
using Messenger.Database.Entities;

namespace Messenger.Core.Models.ChatModels
{
    public interface IChatDtoModel
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    internal class ChatDtoModelProfile : Profile
    {
        public ChatDtoModelProfile()
        {
            CreateMap<Chat, IChatDtoModel>().AsProxy()
                .ForMember(
                    model => model.Name,
                    conf => conf.MapFrom(c => c.Name ?? Constants.ChatValues.NewChatName)
                );
        }
    }
}
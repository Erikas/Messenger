using AutoMapper;
using Messenger.Database.Entities;

namespace Messenger.Core.Models
{
    public interface IUserDtoModel
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    internal class UserDtoModelProfile : Profile
    {
        public UserDtoModelProfile() 
        { 
            CreateMap<User, IUserDtoModel>().AsProxy()
                .ForMember(
                    x => x.Id,
                    e => e.MapFrom(e => e.Id));
        }
    }
}
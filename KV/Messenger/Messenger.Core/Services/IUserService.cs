using AutoMapper;
using Messenger.Core.Models;
using Messenger.Database.Entities;
using Messenger.Database;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Core.Services
{
    public interface IUserService
    {
        IQueryable<IContactDtoModel> GetUserContacts(int userId);
        Task<IUserDtoModel> CreateUserAsync(string userName);
    }

    internal class UserService : IUserService
    {
        private readonly MessengerContext dbContext;
        private readonly IMapper mapper;

        public UserService(MessengerContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IUserDtoModel> CreateUserAsync(string userName)
        {
            var newUser = new User()
            {
                Name = userName,
                ChangeTS = DateTime.Now
            };

            await dbContext.Users.AddAsync(newUser);

            newUser.ContactBook = new ContactBook()

            {
                OwnerUser = newUser,
                ChangeTS = DateTime.Now
                
            };
            await dbContext.SaveChangesAsync();

            return mapper.Map<IUserDtoModel>(newUser);
        }

        public IQueryable<IContactDtoModel> GetUserContacts(int userId)
        {
            var query =
                from ContactBook in dbContext.ContactBooks
                join Contact in dbContext.Contacts on ContactBook.Id equals Contact.ContactBookId
                join User in dbContext.Users on Contact.ContactUserId equals User.Id
                select new ContactDtoModel
                {
                    Id = Contact.Id,
                    Name = User.Name
                };
            
            return query;
        }
    }
}
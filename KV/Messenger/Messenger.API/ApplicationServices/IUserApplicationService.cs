using Messenger.Core.Services;
using System.Threading.Tasks;

namespace Messenger.API.ApplicationServices
{
    public interface IUserApplicationService
    {
        Task<int> Create(string userName);
    }

    internal class UserApplicationService : IUserApplicationService
    {
        private readonly IUserService userService;

        public UserApplicationService(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<int> Create(string userName)
        {
            return await userService.Create(userName);
        }
    }
}
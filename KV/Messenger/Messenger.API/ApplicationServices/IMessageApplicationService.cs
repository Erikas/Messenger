using Messenger.Core.Models;
using Messenger.Core.Services;
using System.Threading.Tasks;

namespace Messenger.API.ApplicationServices
{
    public interface IMessageApplicationService
    {
        Task<int> Create(INewMessageModel model);
    }

    internal class MessageApplicationService : IMessageApplicationService
    {
        private readonly IMessageService messageService;

        public MessageApplicationService(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public async Task<int> Create(INewMessageModel model)
        {
            return await messageService.Create(model);
        }
    }
}
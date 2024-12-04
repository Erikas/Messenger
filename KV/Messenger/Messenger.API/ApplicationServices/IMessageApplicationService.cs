using Messenger.Core.Models;
using Messenger.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.API.ApplicationServices
{
    public interface IMessageApplicationService
    {
        Task<int> Create(INewMessageModel model);
        Task<IEnumerable<IMessageModel>> Get(int id, int? rows);
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

        public async Task<IEnumerable<IMessageModel>> Get(int id, int? rows)
        {
            var query = messageService.Get(id);

            int take = rows ?? 10;

            return await query
                .OrderByDescending(x => x.ChangeTS)
                .ThenByDescending(x => x.Id)
                .Take(take)
                .ToListAsync();
        }
    }
}
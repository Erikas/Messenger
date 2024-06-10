using Messenger.Core.Models;

namespace Messenger.Core.Services
{
    public interface IAttachmentService
    {
        Task<int> Create(INewAttachmentModel model);
        IQueryable<IAttachmentDtoModel> GetDtoQuery();
    }
}
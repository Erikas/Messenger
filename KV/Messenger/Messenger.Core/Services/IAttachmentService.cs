using Messenger.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Core.Services
{
    public interface IAttachmentService
    {
        Task<int> Create(INewAttachmentModel model);
        IQueryable<IAttachmentDtoModel> GetDtoQuery();
    }
}
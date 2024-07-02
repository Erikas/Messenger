using Messenger.API.ApplicationServices;
using Messenger.API.Models;
using Messenger.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Messenger.API.Controllers.Chat
{
    public class MessagesController : ChatBaseController
    {
        private readonly IMessageApplicationService messageApplicationService;

        public MessagesController(IMessageApplicationService messageApplicationService)
        {
            this.messageApplicationService = messageApplicationService;
        }

        [HttpPost]
        [ProducesResponseType<int>(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Post([FromBody] NewMessageModel model)
        {
            var id = await messageApplicationService.Create(model);
            return Created(nameof(Post), id);
        }

        [HttpGet("{id:int}/Messages")]
        [ProducesResponseType<ActionResult<IMessageModel>>(StatusCodes.Status200OK)]
        public async Task<ActionResult<IMessageModel>> GetMessages([FromRoute] int id,
            [FromQuery] int? rows)
        {
            var result = await messageApplicationService.Get(id, rows);
            return Ok(result);
        }
    }
}
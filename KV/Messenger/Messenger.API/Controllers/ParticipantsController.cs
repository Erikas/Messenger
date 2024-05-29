using Messenger.API.ApplicationServices;
using Messenger.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [Route("api/Chats/{chatId:int}/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantApplicationService participantApplicationService;

        public ParticipantsController(IParticipantApplicationService participantApplicationService)
        {
            this.participantApplicationService = participantApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Post([FromRoute] int chatId,
            [FromBody] ParticipantCreationModel model)
        {
            var result = await participantApplicationService.Create(model, chatId);

            return Created(nameof(Post), result);
        }
    }
}
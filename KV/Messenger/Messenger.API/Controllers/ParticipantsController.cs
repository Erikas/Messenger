using Messenger.API.ApplicationServices;
using Messenger.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [Route("Chats/{chatId:int}/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantApplicationService participantApplicationService;

        public ParticipantsController(IParticipantApplicationService participantApplicationService)
        {
            this.participantApplicationService = participantApplicationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ParticipantModel>>> Get([FromRoute] int chatId)
        {
            var result = await participantApplicationService.Get(chatId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Post([FromRoute] int chatId,
            [FromBody] ParticipantCreationModel model)
        {
            var result = await participantApplicationService.Create(model, chatId);

            return Created(nameof(Post), result);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete([FromRoute] int id, [FromQuery] int requestUserId)
        {
            await participantApplicationService.Delete(id, requestUserId);
            return NoContent();
        }
    }
}
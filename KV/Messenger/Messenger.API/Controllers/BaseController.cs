using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        public BaseController()
        {
        }
    }
}
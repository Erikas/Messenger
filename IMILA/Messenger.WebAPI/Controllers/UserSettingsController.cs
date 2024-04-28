using Messenger.Core.Services;
using Messenger.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserSettingsController : Controller
    {
        private readonly UserSettingsService? userSettingsService;

        [HttpGet]
        public async Task<IActionResult> GetAllUserSettings()
        {
            var userSettings = await userSettingsService.GetAllUserSettingsAsync();
            return Ok(userSettings);
        }

        [HttpGet("{userAccountId}")]
        public async Task<IActionResult> GetUserSettings(long userAccountId)
        {
            var userSettings = await userSettingsService.GetUserSettingsAsync(userAccountId);
            if (userSettings == null)
                return NotFound();

            return Ok(userSettings);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserSettings(UserSettings userSettings)
        {
            await userSettingsService.AddUserSettingsAsync(userSettings);
            return CreatedAtAction(nameof(GetUserSettings), new { userAccountId = userSettings.UserAccountId }, userSettings);
        }
    }
}

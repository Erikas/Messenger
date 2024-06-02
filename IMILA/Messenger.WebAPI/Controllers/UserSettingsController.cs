using Messenger.Core.Services;
using Messenger.Persistence.Entities;
using Messenger.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserSettingsController : Controller
    {
        private readonly UserSettingsService _userSettingsService;

        public UserSettingsController(UserSettingsService userSettingsService)
        {
          _userSettingsService = userSettingsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserSettings()
        {
            var userSettings = await _userSettingsService.GetAllUserSettingsAsync();
            return Ok(userSettings);
        }

        [HttpGet("{userAccountId}")]
        public async Task<IActionResult> GetUserSettings(long userAccountId)
        {
          var userSettings = await _userSettingsService.GetUserSettingsAsync(userAccountId);
            if (userSettings == null)
                return NotFound();

            return Ok(userSettings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserSettings([FromBody] UserSettingsDto userSettingsDto)
        {
            // Fetch the UserAccount entity
            var userAccount = await _userSettingsService.GetUserAccountAsync(userSettingsDto.UserAccountId);
            if (userAccount == null)
            {
                return NotFound("User account not found.");
            }

            var userSettings = new UserSettings
            {
                UserAccountId = userSettingsDto.UserAccountId,
                Theme = userSettingsDto.Theme,
                CreationTS = DateTime.UtcNow,
                ModificationTS = DateTime.UtcNow,
                UserAccount = userAccount
            };

            var createdUserSettings = await _userSettingsService.CreateUserSettingsAsync(userSettings);
            return CreatedAtAction(nameof(GetUserSettings), new { userAccountId = createdUserSettings.UserAccountId }, createdUserSettings);
        }
    }
}

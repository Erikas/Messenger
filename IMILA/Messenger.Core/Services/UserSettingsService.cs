using Messenger.Persistence.Context;
using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Core.Services
{
    public class UserSettingsService
    {
        private readonly MessengerDbContext context;

        public UserSettingsService(MessengerDbContext context)
        {
        }

        public async Task<List<UserSettings>> GetAllUserSettingsAsync()
        {
            return await context.UserSettings.ToListAsync();
        }

        public async Task<UserSettings> GetUserSettingsAsync(long userAccountId)
        {
            return await context.UserSettings
                .FirstOrDefaultAsync(us => us.UserAccountId == userAccountId);
        }

        public async Task AddUserSettingsAsync(UserSettings userSettings)
        {
            context.UserSettings.Add(userSettings);
            await context.SaveChangesAsync();
        }
    }
}

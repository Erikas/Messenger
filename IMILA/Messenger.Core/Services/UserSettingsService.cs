using Messenger.Persistence.Context;
using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Core.Services
{
    public class UserSettingsService
    {
        private readonly MessengerDbContext _context;

        public UserSettingsService(MessengerDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserSettings>> GetAllUserSettingsAsync()
        {
            return await _context.UserSettings.ToListAsync();
        }

        public async Task<UserSettings?> GetUserSettingsAsync(long userAccountId)
        {
            return await _context.UserSettings
                .FirstOrDefaultAsync(us => us.UserAccountId == userAccountId);
        }

        public async Task<UserAccount?> GetUserAccountAsync(long userAccountId)
        {
            return await _context.UserAccounts.FindAsync(userAccountId);
        }

        public async Task<UserSettings> CreateUserSettingsAsync(UserSettings userSettings)
        {
            _context.UserSettings.Add(userSettings);
            await _context.SaveChangesAsync();
            return userSettings;
        }
    }
}

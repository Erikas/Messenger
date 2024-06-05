using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Persistence.Configuration
{
    internal class UserSettingsEntityTypeConfiguration : IEntityTypeConfiguration<UserSettings>
    {
        public void Configure(EntityTypeBuilder<UserSettings> builder)
        {
            builder.ToTable(nameof(UserSettings));

            builder.HasOne(us => us.UserAccount)
                   .WithOne(ua => ua.UserSettings)
                   .HasForeignKey<UserSettings>(us => us.UserAccountId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

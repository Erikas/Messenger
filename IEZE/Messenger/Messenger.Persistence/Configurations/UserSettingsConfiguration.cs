using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    internal class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettings>
    {
        public void Configure(EntityTypeBuilder<UserSettings> builder)
        {
            builder.Property(settings => settings.Setting2)
                .HasMaxLength(10);

            builder.HasOne(userprofile => userprofile.User)
                .WithOne(user => user.UserSettings)
                .HasForeignKey<UserSettings>(userprofile => userprofile.UserID);
        }
    }
}

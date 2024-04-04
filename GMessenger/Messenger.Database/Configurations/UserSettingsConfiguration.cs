using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace Messenger.Database.Configurations
{
    public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettings>
    {
        public void Configure(EntityTypeBuilder<UserSettings> builder)
        {
            builder.Property(b => b.Theme).HasMaxLength(10);

            builder
            .HasOne(a => a.User)
            .WithOne(a => a.UserSettings)
            .HasForeignKey<UserSettings>(a => a.UserId);
        }
    }
}

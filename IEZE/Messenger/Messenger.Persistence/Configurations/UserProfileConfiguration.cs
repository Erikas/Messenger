using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    internal class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(profile => profile.FirstName)
                .HasMaxLength(50);

            builder.Property(profile => profile.LastName)
                .HasMaxLength(50);

            builder.Property(profile => profile.Bio)
                .HasMaxLength(1200);

            builder.Property(profile => profile.ProfilePicture)
                .HasMaxLength(1200);

            builder.HasOne(userprofile => userprofile.User)
                .WithOne(user => user.UserProfile)
                .HasForeignKey<UserProfile>(userprofile => userprofile.UserID);
        }
    }
}
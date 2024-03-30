using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfile");

            builder.HasKey(p => p.ProfileID);

            builder.Property(p => p.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.ProfilePicture)
                   .IsRequired();

            builder.Property(p => p.Bio)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(p => p.BirthDate)
                   .IsRequired();

            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.Property(p => p.ModifiedAt)
                   .IsRequired();

            builder.HasOne(us => us.User)
                .WithOne(u => u.UserProfile)
                .HasForeignKey<UserProfile>(us => us.UserID);
        }
    }
}
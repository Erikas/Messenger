using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder
                .Property(u => u.UserName)
                .HasMaxLength(255);

            builder
                .Property(u => u.FirstName)
                .HasMaxLength(40);

            builder
                .Property(u => u.LastName)
                .HasMaxLength(80);

            builder
                .Property(u => u.Email)
                .HasMaxLength(320);

            builder
                .Property(u => u.PhoneNumber)
                .HasMaxLength(10);

            builder
                .Property(u => u.PictureUrl)
                .HasMaxLength(500);
        }
    }
}
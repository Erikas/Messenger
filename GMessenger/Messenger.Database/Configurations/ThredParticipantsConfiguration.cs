using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Configurations
{
    public class ThredParticipantsConfiguration : IEntityTypeConfiguration<ThredParticipants>
    {
        public void Configure(EntityTypeBuilder<ThredParticipants> builder)
        {
            builder
            .HasOne(b => b.Users)
            .WithMany()
            .HasForeignKey(b => b.UserId);

            builder
            .HasOne(b => b.Threds)
            .WithMany()
            .HasForeignKey(b => b.ThredId);
        }
    }
}

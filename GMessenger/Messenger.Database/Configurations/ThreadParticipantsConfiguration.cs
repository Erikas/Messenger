using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Configurations
{
    internal class ThreadParticipantsConfiguration : IEntityTypeConfiguration<ThreadParticipants>
    {
        public void Configure(EntityTypeBuilder<ThreadParticipants> builder)
        {
            builder
             .HasOne(b => b.Thread)
             .WithMany(a => a.ThreadParticipants)
             .HasForeignKey(b => b.ThreadId);

            builder
             .HasOne(b => b.User)
             .WithMany(a => a.ThreadParticipants)
             .HasForeignKey(b => b.UserId);
        }
    }
}
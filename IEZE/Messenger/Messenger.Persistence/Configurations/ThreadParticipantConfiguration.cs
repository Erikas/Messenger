using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    public class ThreadParticipantConfiguration : IEntityTypeConfiguration<ThreadParticipant>
    {
        public void Configure(EntityTypeBuilder<ThreadParticipant> builder)
        {
            builder.ToTable("ThreadParticipants");

            builder.HasKey(tp => tp.ThreadParticipantID);

            builder.Property(tp => tp.ThreadID)
                   .IsRequired();

            builder.Property(tp => tp.UserID)
                   .IsRequired();

            builder.Property(tp => tp.ParticipantType)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasOne(tp => tp.ChatThread)
                   .WithMany()
                   .HasForeignKey(tp => tp.ThreadID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tp => tp.User)
                   .WithMany()
                   .HasForeignKey(tp => tp.UserID)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

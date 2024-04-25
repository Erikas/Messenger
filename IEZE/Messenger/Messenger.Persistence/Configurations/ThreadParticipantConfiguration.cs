using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Messenger.Persistence.Entities;

namespace Messenger.Persistence.Configurations
{
    internal class ThreadParticipantConfiguration : IEntityTypeConfiguration<ThreadParticipant>
    {
        public void Configure(EntityTypeBuilder<ThreadParticipant> builder)
        {
            builder.Property(participant => participant.ParticipantType)
                   .HasMaxLength(20);

            builder.HasOne(participant => participant.ChatThread)
                   .WithMany(thread => thread.ThreadParticipant)
                   .HasForeignKey(participant => participant.ThreadID);

            builder.HasOne(participant => participant.User)
                   .WithMany(user => user.ThreadParticipant)
                   .HasForeignKey(participant => participant.UserID)
                   .OnDelete(DeleteBehavior.Restrict); // meta errora kad "may cause cycles or multiple cascade paths" paziuresiu veliau
        }
    }
}

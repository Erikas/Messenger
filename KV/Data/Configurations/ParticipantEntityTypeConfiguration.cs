using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Data.Configurations
{
    internal class ParticipantEntityTypeConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable(nameof(ContactBook));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ChangeTS)
                   .HasDefaultValue(DateTime.UtcNow);

            builder.HasMany(x => x.SentMessages)
                   .WithOne(x => x.SenderParticipant)
                   .HasForeignKey(x => x.SenderParticipantId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
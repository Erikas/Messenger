using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Messenger.Data.Configurations
{
    internal class ParticipantEntityTypeConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable(nameof(Participant));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ChangeTS)
                   .HasDefaultValue(DateTime.UtcNow);

            builder.HasMany(x => x.SentMessages)
                   .WithOne(x => x.SenderParticipant)
                   .HasForeignKey(x => x.SenderParticipantId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.UserId, x.ChatId })
                   .IsUnique(true);
        }
    }
}
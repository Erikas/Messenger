using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Persistence.Configuration
{
    internal class UserAccountEntityTypeConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasKey(ua => ua.Id);

            builder.HasMany(ua => ua.ThreadMembers)
                   .WithOne(tm => tm.UserAccount)
                   .HasForeignKey(tm => tm.ThreadMemberUserAccountId);

            builder.HasMany(ua => ua.Threads)
                   .WithOne(t => t.UserAccount)
                   .HasForeignKey(t => t.CreationUserAccountId);

            builder.HasMany(ua => ua.Messages)
                   .WithOne(m => m.UserAccount)
                   .HasForeignKey(m => m.SenderUserAccountId);

            builder.HasMany(ua => ua.UserContacts)
                   .WithOne(uc => uc.UserAccount)
                   .HasForeignKey(uc => uc.UserAccountId);

            builder.HasMany(ua => ua.UserContacts)
                   .WithOne(uc => uc.ContactUserAccount)
                   .HasForeignKey(uc => uc.ContactUserAccountId);
        }
    }
}

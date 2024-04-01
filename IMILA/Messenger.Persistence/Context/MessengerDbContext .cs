using Messenger.Persistence.Configuration;
using Messenger.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Thread = Messenger.Persistence.Entities.Thread;

namespace Messenger.Persistence.Context
{
    internal class MessengerDbContext : DbContext
    {
        public MessengerDbContext(DbContextOptions<MessengerDbContext> options) : base(options)
        { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageAttachment> MessageAttachments { get; set; }
        public DbSet<ThreadMember> ThreadMembers { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MessageAttachmentEntityTypeCongifuration());
            modelBuilder.ApplyConfiguration(new ThreadEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ThreadMemberEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserContactEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserSettingsEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

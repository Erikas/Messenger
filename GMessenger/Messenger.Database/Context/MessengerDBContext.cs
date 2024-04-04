using Messenger.Database.Configurations;
using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Messenger.Database.Context
{
    public class MessengerDBContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ThredParticipants> ThredParticipants { get; set; }
        public DbSet<Thred> Threds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AttachmentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FriendConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessageConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThredParticipantsConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThredConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserSettingsConfiguration).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["GMessengerDatabase"].ConnectionString);
    }
}

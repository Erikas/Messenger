using Microsoft.EntityFrameworkCore;
using Messenger.Persistence.Entities;
using Messenger.Persistence.Configurations;
using System.Reflection;

namespace Messenger.Persistence.Models
{
    public class MessengerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friends { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ChatThread> Threads { get; set; }
        public DbSet<ThreadParticipant> ThreadParticipants { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageAttachment> Attachments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=(localdb)\\local;Initial Catalog=Messenger;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}

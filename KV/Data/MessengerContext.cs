using Messenger.Data.Configurations;
using Messenger.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Data
{
    public class MessengerContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public MessengerContext(DbContextOptions<MessengerContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<MessengerContext>).Assembly);
        }
    }
}
using Messenger.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Database.Configurations
{
    public class ThredConfiguration : IEntityTypeConfiguration<Thred>
    {
        public void Configure(EntityTypeBuilder<Thred> builder)
        {
        }
    }
}

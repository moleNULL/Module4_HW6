using EFCore_MusicDB.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_MusicDB.Data.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<ArtistEntity>
    {
        public void Configure(EntityTypeBuilder<ArtistEntity> builder)
        {
            // PRIMARY KEY
            builder.HasKey(a => a.Id);

            // NOT NULL
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);

            // Constraints
            builder.Property(a => a.Phone).HasMaxLength(30);
            builder.Property(a => a.Email).HasMaxLength(100);
            builder.Property(a => a.InstragramUrl).HasMaxLength(300);
        }
    }
}

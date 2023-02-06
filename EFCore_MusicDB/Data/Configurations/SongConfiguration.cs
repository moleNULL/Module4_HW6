using EFCore_MusicDB.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_MusicDB.Data.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<SongEntity>
    {
        public void Configure(EntityTypeBuilder<SongEntity> builder)
        {
            // PRIMARY KEY
            builder.HasKey(s => s.Id);

            // NOT NULL
            builder.Property(s => s.Title).IsRequired().HasMaxLength(75);
            builder.Property(s => s.Duration).IsRequired();
            builder.Property(s => s.ReleaseDate).IsRequired();

            // Relation
            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId);
        }
    }
}

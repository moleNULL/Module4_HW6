using EFCore_MusicDB.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_MusicDB.Data.Configurations
{
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSongEntity>
    {
        public void Configure(EntityTypeBuilder<ArtistSongEntity> builder)
        {
            // PRIMARY KEY
            builder.HasKey(arso => new { arso.ArtistId, arso.SongId });

            // NOT NULL
            builder.Property(arso => arso.ArtistId).IsRequired();
            builder.Property(arso => arso.SongId).IsRequired();

            // Relation
            builder.HasOne(arso => arso.Artist)
                .WithMany(a => a.ArtistSongs)
                .HasForeignKey(arso => arso.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(arso => arso.Song)
                .WithMany(s => s.ArtistSongs)
                .HasForeignKey(arso => arso.SongId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

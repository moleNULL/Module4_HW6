using EFCore_MusicDB.Data.Configurations;
using EFCore_MusicDB.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore_MusicDB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ArtistEntity> Artists { get; set; } = null!;
        public DbSet<GenreEntity> Genres { get; set; } = null!;
        public DbSet<SongEntity> Songs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistSongConfiguration());

            modelBuilder.Seed();
        }
    }
}

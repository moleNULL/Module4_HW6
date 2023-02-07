using EFCore_MusicDB.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore_MusicDB.Data
{
    public static class ModelBuilderExtensions
    {
        // Default values for all tables
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreEntity>().HasData(GetPreconfiguredGenres());

            modelBuilder.Entity<SongEntity>().HasData(GetPreconfiguredSongs());

            modelBuilder.Entity<ArtistEntity>().HasData(GetPreconfiguredArtists());

            modelBuilder.Entity<ArtistSongEntity>().HasData(GetPreconfiguredArtistSongs());
        }

        private static IEnumerable<GenreEntity> GetPreconfiguredGenres()
        {
            return new List<GenreEntity>()
            {
                new GenreEntity() { Id = 1, Title = "Rock" },
                new GenreEntity() { Id = 2, Title = "Metal" },
                new GenreEntity() { Id = 3, Title = "Pop" },
                new GenreEntity() { Id = 4, Title = "Rap" },
                new GenreEntity() { Id = 5, Title = "K-Pop" }
            };
        }

        private static IEnumerable<SongEntity> GetPreconfiguredSongs()
        {
            var songs = new List<SongEntity>()
            {
                new SongEntity()
                {
                    Id = 1,
                    Title = "Remember This",
                    Duration = 238,
                    ReleaseDate = new DateTime(2019, 11, 15),

                    GenreId = 4
                },
                new SongEntity()
                {
                    Id = 2,
                    Title = "Art Of War",
                    Duration = 306,
                    ReleaseDate = new DateTime(2008, 08, 01),

                    GenreId = 2
                },
                new SongEntity()
                {
                    Id = 3,
                    Title = "Hold On",
                    Duration = 312,
                    ReleaseDate = new DateTime(1988, 03, 25),

                    GenreId = 2
                },
                new SongEntity()
                {
                    Id = 4,
                    Title = "Hound Dog",
                    Duration = 136,
                    ReleaseDate = new DateTime(1956, 07, 08),

                    GenreId = 1
                },
                new SongEntity()
                {
                    Id = 5,
                    Title = "7 rings",
                    Duration = 179,
                    ReleaseDate = new DateTime(2019, 01, 18),

                    GenreId = 3
                },
                new SongEntity()
                {
                    Id = 6,
                    Title = "Like A Virgin",
                    Duration = 190,
                    ReleaseDate = new DateTime(1984, 11, 04)
                },
                new SongEntity()
                {
                    Id = 7,
                    Title = "Solo",
                    Duration = 175,
                    ReleaseDate = new DateTime(2018, 11, 12),

                    GenreId = 5
                },
                new SongEntity()
                {
                    Id = 8,
                    Title = "Snapping",
                    Duration = 210,
                    ReleaseDate = new DateTime(2019, 06, 24),

                    GenreId = 5
                }
            };

            return songs;
        }

        private static IEnumerable<ArtistEntity> GetPreconfiguredArtists()
        {
            var artists = new List<ArtistEntity>()
            {
                new ArtistEntity()
                {
                    Id = 1,
                    Name = "NF",
                    DateOfBirth = new DateTime(1991, 03, 30),

                    InstragramUrl = "https://www.instagram.com/nfrealmusic/"
                },
                new ArtistEntity()
                {
                    Id = 2,
                    Name = "Sabaton",
                    DateOfBirth = new DateTime(1981, 11, 25),

                    Phone = "+46701234567",
                    Email = "joakim_broden@gmail.com",
                    InstragramUrl = "https://www.instagram.com/sabaton/"
                },
                new ArtistEntity()
                {
                    Id = 3,
                    Name = "Yngwie J. Malmsteen",
                    DateOfBirth = new DateTime(1963, 06, 30),

                    Email = "yngwie_j_malmsteen_sverige@gmail.com"
                },
                new ArtistEntity()
                {
                    Id = 4,
                    Name = "Elvis Presley",
                    DateOfBirth = new DateTime(1935, 01, 08)
                },
                new ArtistEntity()
                {
                    Id = 5,
                    Name = "Ariana Grande",
                    DateOfBirth = new DateTime(1993, 06, 26),

                    InstragramUrl = "https://www.instagram.com/arianagrande/"
                },
                new ArtistEntity()
                {
                    Id = 6,
                    Name = "Madonna",
                    DateOfBirth = new DateTime(1958, 08, 16),

                    Phone = "+15551234567",
                    Email = "madonnaUS@hotmail.com",
                    InstragramUrl = "https://www.instagram.com/madonna/"
                },
                new ArtistEntity()
                {
                    Id = 7,
                    Name = "Kim Jennie",
                    DateOfBirth = new DateTime(1996, 01, 16),

                    Phone = "+9102225207641",
                    Email = "kim_jenniequeen@gmail.com",
                    InstragramUrl = "https://www.instagram.com/jennierubyjane/"
                },
                new ArtistEntity()
                {
                    Id = 8,
                    Name = "Chung Ha",
                    DateOfBirth = new DateTime(1996, 02, 09),

                    Email = "chungha_korea@gmail.com",
                    InstragramUrl = "https://www.instagram.com/chungha_official/"
                }
            };

            return artists;
        }

        private static IEnumerable<ArtistSongEntity> GetPreconfiguredArtistSongs()
        {
            return new List<ArtistSongEntity>()
            {
                new ArtistSongEntity() { ArtistId = 1, SongId = 1 },
                new ArtistSongEntity() { ArtistId = 2, SongId = 2 },
                new ArtistSongEntity() { ArtistId = 3, SongId = 3 },
                new ArtistSongEntity() { ArtistId = 4, SongId = 4 },
                new ArtistSongEntity() { ArtistId = 5, SongId = 5 },
                new ArtistSongEntity() { ArtistId = 6, SongId = 6 },
                new ArtistSongEntity() { ArtistId = 7, SongId = 7 },
                new ArtistSongEntity() { ArtistId = 8, SongId = 8 }
            };
        }
    }
}

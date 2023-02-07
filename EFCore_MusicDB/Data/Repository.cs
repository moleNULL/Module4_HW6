using Microsoft.EntityFrameworkCore;

namespace EFCore_MusicDB.Data
{
    internal class Repository
    {
        private readonly ApplicationDbContext _dbContext;
        public Repository(DbContextOptions<ApplicationDbContext> options)
        {
            _dbContext = new ApplicationDbContext(options);

            // Create DB if it hasn't been already created by applying all migrations
            _dbContext.Database.Migrate();
        }

        // Print SongTitle, SongArtist and SongGenre only for those songs that have genre
        public void PrintSongInfo()
        {
            Console.WriteLine("1. Print SongTitle, SongArtist and SongGenre" +
                " only for those songs that have genre:\n");

            var songs = from s in _dbContext.Songs
                        join g in _dbContext.Genres on s.GenreId equals g.Id
                        join arso in _dbContext.ArtistSongs on s.Id equals arso.SongId
                        join a in _dbContext.Artists on arso.ArtistId equals a.Id
                        select new
                        {
                            Id = s.Id,
                            Artist = a.Name,
                            SongTitle = s.Title,
                            Genre = g.Title
                        };

            foreach (var song in songs)
            {
                Console.WriteLine($"\t{song.Id}. {song.Artist} - {song.SongTitle}\t\t\t({song.Genre})");
            }

            PrintQueryString(songs.ToQueryString());
        }

        // Print number of songs in each genre
        public void PrintSongNumberPerGenre()
        {
            Console.WriteLine("2. Print number of songs in each genre:\n");

            var groups = _dbContext.Songs
                .GroupBy(s => s!.Genre!.Title)
                .Select(g => new
                {
                    Genre = g.Key ?? "*Undefined*", // in case GenreId is null since song has no Genre
                    Count = g.Count()
                });

            foreach (var songInfo in groups)
            {
                Console.WriteLine($"\t{songInfo.Genre}: {songInfo.Count} songs");
            }

            PrintQueryString(groups.ToQueryString());
        }

        // Print songs that has been written before birth of the youngest artist
        public void PrintTheSongsBeforeYoungestArtistBirth()
        {
            Console.WriteLine("3. Print songs that has been written before birth of the youngest artist:\n");

            DateTime youngertArtist = _dbContext.Artists.Max(a => a.DateOfBirth);

            var songs = from s in _dbContext.Songs
                        join arso in _dbContext.ArtistSongs on s.Id equals arso.SongId
                        join g in _dbContext.Genres on s.GenreId equals g.Id into gs
                        from g in gs.DefaultIfEmpty() // song LEFT OUTER JOIN genre
                        where s.ReleaseDate < youngertArtist
                        select new
                        {
                            Id = s.Id,
                            SongTitle = s.Title,
                            Artist = arso.Artist.Name,
                            Duration = s.Duration,
                            ReleaseDate = s.ReleaseDate.ToShortDateString(),
                            Genre = g.Title ?? "*Undefined*", // in case GenreId is null since song has no Genre
                        };

            foreach (var song in songs)
            {
                Console.WriteLine($"\t{song.Id}. {song.Artist} - {song.SongTitle}\t{song.ReleaseDate}" +
                    $" [{song.Duration} s]\t\t\t({song.Genre})");
            }

            PrintQueryString(songs.ToQueryString());
        }

        // Print formatted raw SQL request
        private void PrintQueryString(string queryString)
        {
            int repeatCount = Console.WindowWidth;

            Console.WriteLine();
            Console.WriteLine(new string('-', repeatCount));
            Console.WriteLine("\tGenerated SQL request:\n");
            Console.WriteLine(queryString);
            Console.WriteLine(new string('-', repeatCount));

            Console.WriteLine();
        }
    }
}

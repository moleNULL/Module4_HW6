namespace EFCore_MusicDB.Data.Entities
{
    public class SongEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int? GenreId { get; set; }
        public GenreEntity? Genre { get; set; }
        public List<ArtistEntity> Artists { get; set; } = new List<ArtistEntity>();
    }
}

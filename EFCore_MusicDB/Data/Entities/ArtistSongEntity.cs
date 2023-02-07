namespace EFCore_MusicDB.Data.Entities
{
    public class ArtistSongEntity
    {
        public int ArtistId { get; set; }
        public ArtistEntity Artist { get; set; } = null!;
        public int SongId { get; set; }
        public SongEntity Song { get; set; } = null!;
    }
}

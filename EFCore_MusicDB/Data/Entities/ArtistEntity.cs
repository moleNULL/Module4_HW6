namespace EFCore_MusicDB.Data.Entities
{
    public class ArtistEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? InstragramUrl { get; set; }

        public List<SongEntity> Songs { get; set; } = new List<SongEntity>();
    }
}

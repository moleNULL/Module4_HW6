namespace EFCore_MusicDB.Data.Entities
{
    public class GenreEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public List<SongEntity> Songs { get; set; } = new List<SongEntity>();
    }
}

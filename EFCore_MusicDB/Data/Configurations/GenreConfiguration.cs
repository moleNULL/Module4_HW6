using EFCore_MusicDB.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_MusicDB.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            // PRIMARY KEY
            builder.HasKey(s => s.Id);

            // NOT NULL
            builder.Property(s => s.Title).IsRequired().HasMaxLength(75);
        }
    }
}

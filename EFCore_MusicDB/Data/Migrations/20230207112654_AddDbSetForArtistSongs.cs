using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMusicDB.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSetForArtistSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSongEntity_Artists_ArtistId",
                table: "ArtistSongEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSongEntity_Songs_SongId",
                table: "ArtistSongEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistSongEntity",
                table: "ArtistSongEntity");

            migrationBuilder.RenameTable(
                name: "ArtistSongEntity",
                newName: "ArtistSongs");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistSongEntity_SongId",
                table: "ArtistSongs",
                newName: "IX_ArtistSongs_SongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistSongs",
                table: "ArtistSongs",
                columns: new[] { "ArtistId", "SongId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSongs_Artists_ArtistId",
                table: "ArtistSongs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSongs_Songs_SongId",
                table: "ArtistSongs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSongs_Artists_ArtistId",
                table: "ArtistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSongs_Songs_SongId",
                table: "ArtistSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistSongs",
                table: "ArtistSongs");

            migrationBuilder.RenameTable(
                name: "ArtistSongs",
                newName: "ArtistSongEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistSongs_SongId",
                table: "ArtistSongEntity",
                newName: "IX_ArtistSongEntity_SongId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistSongEntity",
                table: "ArtistSongEntity",
                columns: new[] { "ArtistId", "SongId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSongEntity_Artists_ArtistId",
                table: "ArtistSongEntity",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSongEntity_Songs_SongId",
                table: "ArtistSongEntity",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreMusicDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InstragramUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSongEntity",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSongEntity", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_ArtistSongEntity_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSongEntity_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "DateOfBirth", "Email", "InstragramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1991, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://www.instagram.com/nfrealmusic/", "NF", null },
                    { 2, new DateTime(1981, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "joakim_broden@gmail.com", "https://www.instagram.com/sabaton/", "Sabaton", "+46701234567" },
                    { 3, new DateTime(1963, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "yngwie_j_malmsteen_sverige@gmail.com", null, "Yngwie J. Malmsteen", null },
                    { 4, new DateTime(1935, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Elvis Presley", null },
                    { 5, new DateTime(1993, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://www.instagram.com/arianagrande/", "Ariana Grande", null },
                    { 6, new DateTime(1958, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "madonnaUS@hotmail.com", "https://www.instagram.com/madonna/", "Madonna", "+15551234567" },
                    { 7, new DateTime(1996, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "kim_jenniequeen@gmail.com", "https://www.instagram.com/jennierubyjane/", "Kim Jennie", "+9102225207641" },
                    { 8, new DateTime(1996, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "chungha_korea@gmail.com", "https://www.instagram.com/chungha_official/", "Chung Ha", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Metal" },
                    { 3, "Pop" },
                    { 4, "Rap" },
                    { 5, "K-Pop" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "GenreId", "ReleaseDate", "Title" },
                values: new object[] { 6, 190, null, new DateTime(1984, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Like A Virgin" });

            migrationBuilder.InsertData(
                table: "ArtistSongEntity",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[] { 6, 6 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "GenreId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 238, 4, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Remember This" },
                    { 2, 306, 2, new DateTime(2008, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Art Of War" },
                    { 3, 312, 2, new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hold On" },
                    { 4, 136, 1, new DateTime(1956, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hound Dog" },
                    { 5, 179, 3, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "7 rings" },
                    { 7, 175, 5, new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solo" },
                    { 8, 210, 5, new DateTime(2019, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Snapping" }
                });

            migrationBuilder.InsertData(
                table: "ArtistSongEntity",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 7, 7 },
                    { 8, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSongEntity_SongId",
                table: "ArtistSongEntity",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSongEntity");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InClass7.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Album = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Album", "Artist", "ReleaseDate", "Title" },
                values: new object[] { 1, "Led Zepplin IV", "Led Zepplin", new DateTime(1971, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stairway to Heaven" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Album", "Artist", "ReleaseDate", "Title" },
                values: new object[] { 2, "A Night at the Opera", "Queen", new DateTime(1975, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bohemian Rhapsody" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Album", "Artist", "ReleaseDate", "Title" },
                values: new object[] { 3, "Aerosmith", "Aerosmith", new DateTime(1973, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dream On" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}

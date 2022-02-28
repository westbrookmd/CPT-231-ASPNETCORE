using Microsoft.EntityFrameworkCore.Migrations;

namespace InClassU2M6.Migrations
{
    public partial class Player : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Name" },
                values: new object[] { 1, "Magnus Carlson" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Name" },
                values: new object[] { 2, "Ian Nepomniachtchi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}

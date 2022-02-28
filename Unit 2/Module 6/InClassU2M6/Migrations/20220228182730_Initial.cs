using Microsoft.EntityFrameworkCore.Migrations;

namespace InClassU2M6.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chess",
                columns: table => new
                {
                    ChessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moves = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chess", x => x.ChessID);
                });

            migrationBuilder.InsertData(
                table: "Chess",
                columns: new[] { "ChessID", "Moves", "Name" },
                values: new object[] { 1, "1.e4", "King's Pawn" });

            migrationBuilder.InsertData(
                table: "Chess",
                columns: new[] { "ChessID", "Moves", "Name" },
                values: new object[] { 2, "1.e4 c5", "Sicilian Defense" });

            migrationBuilder.InsertData(
                table: "Chess",
                columns: new[] { "ChessID", "Moves", "Name" },
                values: new object[] { 3, "1.e4 e5 2.Nf3 Nc6 3.Bc4 ", "Italian Game" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chess");
        }
    }
}

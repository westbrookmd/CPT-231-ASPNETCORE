using Microsoft.EntityFrameworkCore.Migrations;

namespace M11Assignment.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "X", "Y" },
                values: new object[,]
                {
                    { 1, "You are in a room with exits to the North, East, South, and West.", 0, 0 },
                    { 2, "You are in a room with an exit to the West.", 1, 0 },
                    { 3, "You are in a room with an exit to the South.", 0, 1 },
                    { 4, "You are in a room with an exit to the East.", -1, 0 },
                    { 5, "You are in a room with an exit to the North.", 0, -1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}

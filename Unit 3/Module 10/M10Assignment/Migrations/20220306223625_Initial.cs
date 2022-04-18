using Microsoft.EntityFrameworkCore.Migrations;

namespace M10Assignment.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportID);
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "AirportID", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "GSP", "Greenville-Spartanburg-Anderson" },
                    { 2, "GMU", "Greenville Downtown Airport" },
                    { 3, "GYH", "Donaldson Field Airport" },
                    { 4, "SPA", "Spartanburg Downtown Airport" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}

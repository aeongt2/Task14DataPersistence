using Microsoft.EntityFrameworkCore.Migrations;

namespace Task14DataPersistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainTemp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    temp = table.Column<float>(type: "REAL", nullable: false),
                    feels_like = table.Column<float>(type: "REAL", nullable: false),
                    temp_min = table.Column<float>(type: "REAL", nullable: false),
                    temp_max = table.Column<float>(type: "REAL", nullable: false),
                    pressure = table.Column<int>(type: "INTEGER", nullable: false),
                    humidity = table.Column<int>(type: "INTEGER", nullable: false),
                    sea_level = table.Column<int>(type: "INTEGER", nullable: false),
                    grnd_level = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTemp", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainTemp");
        }
    }
}

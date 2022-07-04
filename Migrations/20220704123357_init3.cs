using Microsoft.EntityFrameworkCore.Migrations;

namespace Task14DataPersistence.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "APIModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeatherId",
                table: "APIModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CitiesList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Province = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    main = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APIModel_CityId",
                table: "APIModel",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_APIModel_WeatherId",
                table: "APIModel",
                column: "WeatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_APIModel_CitiesList_CityId",
                table: "APIModel",
                column: "CityId",
                principalTable: "CitiesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_APIModel_Weather_WeatherId",
                table: "APIModel",
                column: "WeatherId",
                principalTable: "Weather",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APIModel_CitiesList_CityId",
                table: "APIModel");

            migrationBuilder.DropForeignKey(
                name: "FK_APIModel_Weather_WeatherId",
                table: "APIModel");

            migrationBuilder.DropTable(
                name: "CitiesList");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropIndex(
                name: "IX_APIModel_CityId",
                table: "APIModel");

            migrationBuilder.DropIndex(
                name: "IX_APIModel_WeatherId",
                table: "APIModel");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "APIModel");

            migrationBuilder.DropColumn(
                name: "WeatherId",
                table: "APIModel");
        }
    }
}

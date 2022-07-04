using Microsoft.EntityFrameworkCore.Migrations;

namespace Task14DataPersistence.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WindId",
                table: "APIModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Winds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    speed = table.Column<float>(type: "REAL", nullable: false),
                    deg = table.Column<int>(type: "INTEGER", nullable: false),
                    gust = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APIModel_WindId",
                table: "APIModel",
                column: "WindId");

            migrationBuilder.AddForeignKey(
                name: "FK_APIModel_Winds_WindId",
                table: "APIModel",
                column: "WindId",
                principalTable: "Winds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APIModel_Winds_WindId",
                table: "APIModel");

            migrationBuilder.DropTable(
                name: "Winds");

            migrationBuilder.DropIndex(
                name: "IX_APIModel_WindId",
                table: "APIModel");

            migrationBuilder.DropColumn(
                name: "WindId",
                table: "APIModel");
        }
    }
}

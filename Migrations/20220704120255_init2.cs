using Microsoft.EntityFrameworkCore.Migrations;

namespace Task14DataPersistence.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    MainTempId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_APIModel_MainTemp_MainTempId",
                        column: x => x.MainTempId,
                        principalTable: "MainTemp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APIModel_MainTempId",
                table: "APIModel",
                column: "MainTempId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIModel");
        }
    }
}

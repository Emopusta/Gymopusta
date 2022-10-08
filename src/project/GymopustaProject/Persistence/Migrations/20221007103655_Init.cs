using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoveAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveAreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveAreaId = table.Column<int>(type: "int", nullable: false),
                    MoveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_MoveAreas_MoveAreaId",
                        column: x => x.MoveAreaId,
                        principalTable: "MoveAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MoveAreas",
                columns: new[] { "Id", "MoveAreaName", "MoveId" },
                values: new object[] { 1, "Chest", 1 });

            migrationBuilder.InsertData(
                table: "Moves",
                columns: new[] { "Id", "Description", "MoveAreaId", "MoveName" },
                values: new object[] { 1, "blabla bla bla", 1, "Chest Press" });

            migrationBuilder.CreateIndex(
                name: "IX_Moves_MoveAreaId",
                table: "Moves",
                column: "MoveAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "MoveAreas");
        }
    }
}

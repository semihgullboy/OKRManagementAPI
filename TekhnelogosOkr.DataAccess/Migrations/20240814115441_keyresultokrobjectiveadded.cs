using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhnelogosOkr.DataAccess.Migrations
{
    public partial class keyresultokrobjectiveadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyResultOkrObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyResultId = table.Column<int>(type: "int", nullable: true),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyResultOkrObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyResultOkrObjectives_KeyResults_KeyResultId",
                        column: x => x.KeyResultId,
                        principalTable: "KeyResults",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KeyResultOkrObjectives_OkrObjectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "OkrObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyResultOkrObjectives_KeyResultId",
                table: "KeyResultOkrObjectives",
                column: "KeyResultId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyResultOkrObjectives_ObjectiveId",
                table: "KeyResultOkrObjectives",
                column: "ObjectiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyResultOkrObjectives");
        }
    }
}

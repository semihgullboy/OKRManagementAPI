using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhnelogosOkr.DataAccess.Migrations
{
    public partial class suggestionscreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyResultId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    ReceiverId = table.Column<int>(type: "int", nullable: true),
                    isAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_KeyResults_KeyResultId",
                        column: x => x.KeyResultId,
                        principalTable: "KeyResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suggestions_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suggestions_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_KeyResultId",
                table: "Suggestions",
                column: "KeyResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ReceiverId",
                table: "Suggestions",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_SenderId",
                table: "Suggestions",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suggestions");
        }
    }
}

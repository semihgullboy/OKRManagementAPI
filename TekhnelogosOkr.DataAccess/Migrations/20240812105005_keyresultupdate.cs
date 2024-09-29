using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhnelogosOkr.DataAccess.Migrations
{
    public partial class keyresultupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyResults_Users_UserId",
                table: "KeyResults");

            migrationBuilder.DropIndex(
                name: "IX_KeyResults_UserId",
                table: "KeyResults");

            migrationBuilder.DropColumn(
                name: "ObjectiveId",
                table: "KeyResults");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "KeyResults");

            migrationBuilder.CreateIndex(
                name: "IX_KeyResults_OwnerId",
                table: "KeyResults",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyResults_Users_OwnerId",
                table: "KeyResults",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyResults_Users_OwnerId",
                table: "KeyResults");

            migrationBuilder.DropIndex(
                name: "IX_KeyResults_OwnerId",
                table: "KeyResults");

            migrationBuilder.AddColumn<int>(
                name: "ObjectiveId",
                table: "KeyResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "KeyResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KeyResults_UserId",
                table: "KeyResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyResults_Users_UserId",
                table: "KeyResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

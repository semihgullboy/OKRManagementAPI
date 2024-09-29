using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhnelogosOkr.DataAccess.Migrations
{
    public partial class tabloguncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OkrObjectiveUsers_Users_UserId",
                table: "OkrObjectiveUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "OkrObjectiveUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OkrObjectiveUsers_Users_UserId",
                table: "OkrObjectiveUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OkrObjectiveUsers_Users_UserId",
                table: "OkrObjectiveUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "OkrObjectiveUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OkrObjectiveUsers_Users_UserId",
                table: "OkrObjectiveUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

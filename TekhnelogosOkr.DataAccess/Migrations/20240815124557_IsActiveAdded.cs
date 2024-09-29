using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhnelogosOkr.DataAccess.Migrations
{
    public partial class IsActiveAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Suggestions",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Statuses",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OkrObjectiveUsers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OkrObjectiveTransactions",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OkrObjectives",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "KeyResults",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "KeyResultOkrObjectives",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CompanyObjectives",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CompanyObjectiveOkrObjectives",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OkrObjectiveUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OkrObjectiveTransactions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OkrObjectives");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "KeyResults");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "KeyResultOkrObjectives");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CompanyObjectives");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CompanyObjectiveOkrObjectives");
        }
    }
}

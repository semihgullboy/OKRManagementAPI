using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhnelogosOkr.DataAccess.Migrations
{
    public partial class OkrObjectivesTransactionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OkrObjectiveTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkrObjectiveId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrObjectiveTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OkrObjectiveTransactions_OkrObjectives_OkrObjectiveId",
                        column: x => x.OkrObjectiveId,
                        principalTable: "OkrObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OkrObjectiveTransactions_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OkrObjectiveTransactions_OkrObjectiveId",
                table: "OkrObjectiveTransactions",
                column: "OkrObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_OkrObjectiveTransactions_UpdatedByUserId",
                table: "OkrObjectiveTransactions",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OkrObjectiveTransactions");
        }
    }
}

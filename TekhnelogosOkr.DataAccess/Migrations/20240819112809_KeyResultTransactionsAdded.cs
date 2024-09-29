using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhnelogosOkr.DataAccess.Migrations
{
    public partial class KeyResultTransactionsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyResultTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyResultId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingRate = table.Column<int>(type: "int", nullable: false),
                    EndingRate = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyResultTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyResultTransactions_KeyResults_KeyResultId",
                        column: x => x.KeyResultId,
                        principalTable: "KeyResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeyResultTransactions_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyResultTransactions_KeyResultId",
                table: "KeyResultTransactions",
                column: "KeyResultId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyResultTransactions_UpdatedByUserId",
                table: "KeyResultTransactions",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyResultTransactions");
        }
    }
}

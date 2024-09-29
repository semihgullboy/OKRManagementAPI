using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TekhnelogosOkr.DataAccess.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentManagerID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartWorkDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    ManagerID = table.Column<int>(type: "int", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyObjectives_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OkrObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OkrObjectives_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyObjectiveOkrObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyObjectiveId = table.Column<int>(type: "int", nullable: false),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyObjectiveOkrObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyObjectiveOkrObjectives_CompanyObjectives_CompanyObjectiveId",
                        column: x => x.CompanyObjectiveId,
                        principalTable: "CompanyObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyObjectiveOkrObjectives_OkrObjectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "OkrObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeyResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    OkrObjectiveId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyResults_OkrObjectives_OkrObjectiveId",
                        column: x => x.OkrObjectiveId,
                        principalTable: "OkrObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeyResults_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KeyResults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OkrObjectiveUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkrObjectiveId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OkrObjectiveUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OkrObjectiveUsers_OkrObjectives_OkrObjectiveId",
                        column: x => x.OkrObjectiveId,
                        principalTable: "OkrObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OkrObjectiveUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[] { 1, "Devam Ediyor" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[] { 2, "Tamamlandı" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[] { 3, "Vazgeçildi" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyObjectiveOkrObjectives_CompanyObjectiveId",
                table: "CompanyObjectiveOkrObjectives",
                column: "CompanyObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyObjectiveOkrObjectives_ObjectiveId",
                table: "CompanyObjectiveOkrObjectives",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyObjectives_StatusId",
                table: "CompanyObjectives",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyResults_OkrObjectiveId",
                table: "KeyResults",
                column: "OkrObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyResults_StatusId",
                table: "KeyResults",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyResults_UserId",
                table: "KeyResults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OkrObjectives_StatusId",
                table: "OkrObjectives",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OkrObjectiveUsers_OkrObjectiveId",
                table: "OkrObjectiveUsers",
                column: "OkrObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_OkrObjectiveUsers_UserId",
                table: "OkrObjectiveUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentID",
                table: "Users",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ManagerID",
                table: "Users",
                column: "ManagerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyObjectiveOkrObjectives");

            migrationBuilder.DropTable(
                name: "KeyResults");

            migrationBuilder.DropTable(
                name: "OkrObjectiveUsers");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "CompanyObjectives");

            migrationBuilder.DropTable(
                name: "OkrObjectives");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMiddleware.Core.Migrations
{
    public partial class dbIniti111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "SystemPreferences",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferenceCode = table.Column<string>(nullable: true),
                    PreferenceValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemPreferences", x => x.PreferenceId);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<int>(nullable: false),
                    RequestGuid = table.Column<string>(nullable: true),
                    RequestTime = table.Column<DateTime>(nullable: false),
                    ElapsedMilliseconds = table.Column<long>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    IsSuccess = table.Column<bool>(nullable: false),
                    Method = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    QueryString = table.Column<string>(nullable: true),
                    RequestBody = table.Column<byte[]>(nullable: true),
                    ResponseBody = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Projects_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ProjectCode",
                table: "Requests",
                column: "ProjectCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "SystemPreferences");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}

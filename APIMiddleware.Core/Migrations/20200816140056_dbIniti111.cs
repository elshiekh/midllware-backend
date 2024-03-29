﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMiddleware.Core.Migrations
{
    public partial class dbIniti111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Projects",
            //    columns: table => new
            //    {
            //        ProjectId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProjectName = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Projects", x => x.ProjectId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SystemPreferences",
            //    columns: table => new
            //    {
            //        PreferenceId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PreferenceCode = table.Column<string>(nullable: true),
            //        PreferenceValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SystemPreferences", x => x.PreferenceId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Requests",
            //    columns: table => new
            //    {
            //        RequestId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProjectId = table.Column<int>(nullable: false),
            //        RequestGuid = table.Column<string>(nullable: true),
            //        RequestTime = table.Column<DateTime>(nullable: false),
            //        ElapsedMilliseconds = table.Column<long>(nullable: false),
            //        ResponseCode = table.Column<int>(nullable: false),
            //        RequestStatus = table.Column<bool>(nullable: false),
            //        RequestMethod = table.Column<string>(nullable: true),
            //        RequestUrl = table.Column<string>(nullable: true),
            //        QueryString = table.Column<string>(nullable: true),
            //        RequestBody = table.Column<byte[]>(nullable: true),
            //        ResponseBody = table.Column<byte[]>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Requests", x => x.RequestId);
            //        table.ForeignKey(
            //            name: "FK_Requests_Projects_ProjectCode",
            //            column: x => x.ProjectId,
            //            principalTable: "Projects",
            //            principalColumn: "ProjectId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Requests_ProjectCode",
            //    table: "Requests",
            //    column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Requests");

            //migrationBuilder.DropTable(
            //    name: "SystemPreferences");

            //migrationBuilder.DropTable(
            //    name: "Projects");
        }
    }
}

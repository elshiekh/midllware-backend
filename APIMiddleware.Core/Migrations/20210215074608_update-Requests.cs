using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMiddleware.Core.Migrations
{
    public partial class updateRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IP_Address",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestMethod",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestUrl",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ResponseCode",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Creation_Date",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IP_Address",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_Update_Date",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Last_Updated_By",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestFormat",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestFunction",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestMethod",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatus",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RequestUrl",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponseFormat",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseCode",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RowVersion",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Requests",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "CREATED_BY",
            //    table: "Projects",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "CREATION_DATE",
            //    table: "Projects",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "LAST_UPDATED_BY",
            //    table: "Projects",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "LAST_UPDATE_DATE",
            //    table: "Projects",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "ProjectId",
            //    table: "Projects",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "RowVersion",
            //    table: "Projects",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Creation_Date",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IP_Address",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Last_Update_Date",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Last_Updated_By",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestFormat",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestFunction",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestMethod",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestStatus",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestUrl",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ResponseFormat",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ResponseCode",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Requests");

            //migrationBuilder.DropColumn(
            //    name: "CREATED_BY",
            //    table: "Projects");

            //migrationBuilder.DropColumn(
            //    name: "CREATION_DATE",
            //    table: "Projects");

            //migrationBuilder.DropColumn(
            //    name: "LAST_UPDATED_BY",
            //    table: "Projects");

            //migrationBuilder.DropColumn(
            //    name: "LAST_UPDATE_DATE",
            //    table: "Projects");

            //migrationBuilder.DropColumn(
            //    name: "ProjectId",
            //    table: "Projects");

            //migrationBuilder.DropColumn(
            //    name: "RowVersion",
            //    table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "IP_Address",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestMethod",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestUrl",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseCode",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

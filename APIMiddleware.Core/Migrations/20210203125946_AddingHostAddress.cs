using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMiddleware.Core.Migrations
{
    public partial class AddingHostAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IP_Address",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IP_Address",
                table: "Requests");
        }
    }
}

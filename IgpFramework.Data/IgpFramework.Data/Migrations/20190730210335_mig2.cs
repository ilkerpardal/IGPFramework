using Microsoft.EntityFrameworkCore.Migrations;

namespace IgpFramework.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "IGP_USER_SESSIONS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "IGP_USER_SESSIONS");
        }
    }
}

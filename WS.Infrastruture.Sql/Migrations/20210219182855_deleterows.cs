using Microsoft.EntityFrameworkCore.Migrations;

namespace WS.Infrastruture.Sql.Migrations
{
    public partial class deleterows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Orders");
        }
    }
}

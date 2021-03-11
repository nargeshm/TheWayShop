using Microsoft.EntityFrameworkCore.Migrations;

namespace WS.Infrastruture.Sql.Migrations
{
    public partial class addShippingMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentNote",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ShippingMethod",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingMethod",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "PaymentNote",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WS.Infrastruture.Sql.Migrations
{
    public partial class addQTY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Products_ProductId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Medias",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_ProductId",
                table: "Medias",
                newName: "IX_Medias_ProductID");

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Medias",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Products_ProductID",
                table: "Medias",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Products_ProductID",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Medias",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_ProductID",
                table: "Medias",
                newName: "IX_Medias_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Medias",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Products_ProductId",
                table: "Medias",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

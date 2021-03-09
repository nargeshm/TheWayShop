using Microsoft.EntityFrameworkCore.Migrations;

namespace WS.Infrastruture.Sql.Migrations
{
    public partial class productidToMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Products_ProductID",
                table: "Medias");

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
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Products_ProductId",
                table: "Medias",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Products_ProductID",
                table: "Medias",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

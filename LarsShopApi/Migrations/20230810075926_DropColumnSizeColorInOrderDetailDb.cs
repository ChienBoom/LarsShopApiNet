using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsShopApi.Migrations
{
    public partial class DropColumnSizeColorInOrderDetailDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_color_ColorId",
                table: "order_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_size_SizeId",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_detail_ColorId",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_detail_SizeId",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "order_detail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ColorId",
                table: "order_detail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SizeId",
                table: "order_detail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_ColorId",
                table: "order_detail",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_SizeId",
                table: "order_detail",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_color_ColorId",
                table: "order_detail",
                column: "ColorId",
                principalTable: "color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_size_SizeId",
                table: "order_detail",
                column: "SizeId",
                principalTable: "size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

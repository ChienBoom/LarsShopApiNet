using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsShopApi.Migrations
{
    public partial class UpdateDbV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "product",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "category",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "product");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "category");
        }
    }
}

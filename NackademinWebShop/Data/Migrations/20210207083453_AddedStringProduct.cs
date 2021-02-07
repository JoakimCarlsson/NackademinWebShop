using Microsoft.EntityFrameworkCore.Migrations;

namespace NackademinWebShop.Data.Migrations
{
    public partial class AddedStringProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductPicture",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPicture",
                table: "Products");
        }
    }
}

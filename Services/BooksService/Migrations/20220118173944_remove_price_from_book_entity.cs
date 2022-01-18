using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksService.Migrations
{
    public partial class remove_price_from_book_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Books",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

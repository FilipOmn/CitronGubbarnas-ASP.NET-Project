using Microsoft.EntityFrameworkCore.Migrations;

namespace Candyshop.Migrations
{
    public partial class AddedRatingtoCandy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Candies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Candies");
        }
    }
}

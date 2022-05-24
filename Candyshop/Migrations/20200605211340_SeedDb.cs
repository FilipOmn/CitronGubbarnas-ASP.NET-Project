using Microsoft.EntityFrameworkCore.Migrations;

namespace Candyshop.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categores",
                columns: new[] { "CategoryId", "CategoryDescriptin", "CategoryName" },
                values: new object[,]
                {
                    { 1, null, "Chocolate Candy" },
                    { 2, null, "Fruit Candy" },
                    { 3, null, "Gummy Candy" },
                    { 4, null, "Halloween Candy" },
                    { 5, null, "Hard Candy" }
                });

            migrationBuilder.InsertData(
                table: "Candies",
                columns: new[] { "CandyId", "CategoryId", "Description", "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\thumbnail\\chocolet-Thumbnail.jpg", "~\\Images\\chocolet.candy.jpg", true, false, "Assorted Chocolet Candy", 4.95m },
                    { 2, 1, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\thumbnail\\chocolateCandy-small.jpg", "~\\Images\\chocolateCandy.jpg", true, true, "Assorted Chocolet Candy", 3.95m },
                    { 3, 1, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\thumbnail\\chocolateCandy2-small.jpg", "~\\Images\\chocolateCandy2.jpg", true, true, "Assorted Chocolet Candy", 295m },
                    { 4, 1, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\thumbnail\\chocolateCandy3-small.jpg", "~\\Images\\chocolateCandy3.jpg", false, true, "Assorted Chocolet Candy", 6.95m },
                    { 5, 2, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\thumbnail\\FruitCandy-small.jpg", "~\\Images\\FruitCandy.jpg", true, true, "Assorted Fruit Candy", 6.95m },
                    { 6, 2, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\thumbnail\\fruitCandy2-small.jpg", "~\\Images\\fruitCandy2.jpg", true, false, "Assorted Fruit Candy", 3.95m },
                    { 7, 2, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\fruitCandy3-small.jpg", "~\\Images\\fruitCandy3.jpg", false, true, "Assorted Fruit Candy", 4.95m },
                    { 8, 3, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\gummyCandy-small.jpg", "~\\Images\\gummyCandy.jpg", true, false, "Assorted Gummy Candy", 4.95m },
                    { 9, 3, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\gummyCandy2-small.jpg", "~\\Images\\gummyCandy2.jpg", true, true, "Assorted Gummy Candy", 6.95m },
                    { 10, 3, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\gummyCandy3-small.jpg", "~\\Images\\gummyCandy3.jpg", true, true, "Assorted Gummy Candy", 4.95m },
                    { 11, 4, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\halloweenCandy-small.jpg", "~\\Images\\halloweenCandy.jpg", true, true, "Assorted Halloween Candy", 3.95m },
                    { 12, 4, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\halloweenCandy2-small.jpg", "~\\Images\\halloweenCandy2.jpg", false, true, "Assorted Halloween Candy", 5.95m },
                    { 13, 4, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\halloweenCandy3-small.jpg", "~\\Images\\halloweenCandy3.jpg", true, true, "Assorted Halloween Candy", 6.95m },
                    { 14, 5, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\hardCandy-small.jpg", "~\\Images\\hardCandy.jpg", true, false, "Assorted Hard Candy", 3.95m },
                    { 15, 5, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\hardCandy2-small.jpg", "~\\Images\\hardCandy2.jpg", false, true, "Assorted Hard Candy", 2.95m },
                    { 16, 5, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\hardCandy3-small.jpg", "~\\Images\\hardCandy3.jpg", true, true, "Assorted Hard Candy", 5.95m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categores",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categores",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categores",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categores",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categores",
                keyColumn: "CategoryId",
                keyValue: 5);
        }
    }
}

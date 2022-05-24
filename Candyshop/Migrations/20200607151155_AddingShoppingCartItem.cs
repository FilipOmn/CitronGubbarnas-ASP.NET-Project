using Microsoft.EntityFrameworkCore.Migrations;

namespace Candyshop.Migrations
{
    public partial class AddingShoppingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 16);

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<string>(nullable: true),
                    CandyId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Candies_CandyId",
                        column: x => x.CandyId,
                        principalTable: "Candies",
                        principalColumn: "CandyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 1,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl" },
                values: new object[] { "\\Images\\thumbnails\\chocolet-Thumbnail.jpg", "\\Images\\chocolet.candy.jpg" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 2,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl" },
                values: new object[] { "\\Images\\thumbnails\\chocolateCandy-small.jpg", "\\Images\\chocolateCandy.jpg" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 3,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "Price" },
                values: new object[] { "\\Images\\thumbnails\\chocolateCandy2-small.jpg", "\\Images\\chocolateCandy2.jpg", 2.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 4,
                columns: new[] { "CategoryId", "ImageThumbnailUrl", "ImageUrl", "IsInStock", "Name" },
                values: new object[] { 2, "\\Images\\thumbnails\\FruitCandy-small.jpg", "\\Images\\FruitCandy.jpg", true, "Assorted Fruit Candy" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 5,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsOnSale", "Price" },
                values: new object[] { "\\Images\\thumbnails\\fruitCandy2-small.jpg", "\\Images\\fruitCandy2.jpg", false, 3.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 6,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Price" },
                values: new object[] { "\\Images\\thumbnails\\fruitCandy3-small.jpg", "\\Images\\fruitCandy3.jpg", false, true, 4.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 7,
                columns: new[] { "CategoryId", "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Name" },
                values: new object[] { 3, "\\Images\\thumbnails\\gummyCandy-small.jpg", "\\Images\\gummyCandy.jpg", true, false, "Assorted Gummy Candy" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 8,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsOnSale", "Price" },
                values: new object[] { "\\Images\\thumbnails\\gummyCandy2-small.jpg", "\\Images\\gummyCandy2.jpg", true, 6.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 9,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "Price" },
                values: new object[] { "\\Images\\thumbnails\\gummyCandy3-small.jpg", "\\Images\\gummyCandy3.jpg", 4.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 10,
                columns: new[] { "CategoryId", "ImageThumbnailUrl", "ImageUrl", "Name", "Price" },
                values: new object[] { 4, "\\Images\\thumbnails\\halloweenCandy-small.jpg", "\\Images\\halloweenCandy.jpg", "Assorted Halloween Candy", 3.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 11,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsInStock", "Price" },
                values: new object[] { "\\Images\\thumbnails\\halloweenCandy2-small.jpg", "\\Images\\halloweenCandy2.jpg", false, 5.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 12,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsInStock", "Price" },
                values: new object[] { "\\Images\\thumbnails\\halloweenCandy3-small.jpg", "\\Images\\halloweenCandy3.jpg", true, 6.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 13,
                columns: new[] { "CategoryId", "ImageThumbnailUrl", "ImageUrl", "IsOnSale", "Name", "Price" },
                values: new object[] { 5, "\\Images\\thumbnails\\hardCandy-small.jpg", "\\Images\\hardCandy.jpg", false, "Assorted Hard Candy", 3.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 14,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Price" },
                values: new object[] { "\\Images\\thumbnails\\hardCandy2-small.jpg", "\\Images\\hardCandy2.jpg", false, true, 2.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 15,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsInStock", "Price" },
                values: new object[] { "\\Images\\thumbnails\\hardCandy3.jpg", "\\Images\\hardCandy3.jpg", true, 5.95m });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_CandyId",
                table: "ShoppingCartItems",
                column: "CandyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 1,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl" },
                values: new object[] { "~\\Images\\thumbnail\\chocolet-Thumbnail.jpg", "~\\Images\\chocolet.candy.jpg" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 2,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl" },
                values: new object[] { "~\\Images\\thumbnail\\chocolateCandy-small.jpg", "~\\Images\\chocolateCandy.jpg" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 3,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "Price" },
                values: new object[] { "~\\Images\\thumbnail\\chocolateCandy2-small.jpg", "~\\Images\\chocolateCandy2.jpg", 295m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 4,
                columns: new[] { "CategoryId", "ImageThumbnailUrl", "ImageUrl", "IsInStock", "Name" },
                values: new object[] { 1, "~\\Images\\thumbnail\\chocolateCandy3-small.jpg", "~\\Images\\chocolateCandy3.jpg", false, "Assorted Chocolet Candy" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 5,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsOnSale", "Price" },
                values: new object[] { "~\\Images\\thumbnail\\FruitCandy-small.jpg", "~\\Images\\FruitCandy.jpg", true, 6.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 6,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Price" },
                values: new object[] { "~\\Images\\thumbnail\\fruitCandy2-small.jpg", "~\\Images\\fruitCandy2.jpg", true, false, 3.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 7,
                columns: new[] { "CategoryId", "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Name" },
                values: new object[] { 2, "~\\Images\\fruitCandy3-small.jpg", "~\\Images\\fruitCandy3.jpg", false, true, "Assorted Fruit Candy" });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 8,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsOnSale", "Price" },
                values: new object[] { "~\\Images\\gummyCandy-small.jpg", "~\\Images\\gummyCandy.jpg", false, 4.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 9,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "Price" },
                values: new object[] { "~\\Images\\gummyCandy2-small.jpg", "~\\Images\\gummyCandy2.jpg", 6.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 10,
                columns: new[] { "CategoryId", "ImageThumbnailUrl", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "~\\Images\\gummyCandy3-small.jpg", "~\\Images\\gummyCandy3.jpg", "Assorted Gummy Candy", 4.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 11,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsInStock", "Price" },
                values: new object[] { "~\\Images\\halloweenCandy-small.jpg", "~\\Images\\halloweenCandy.jpg", true, 3.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 12,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsInStock", "Price" },
                values: new object[] { "~\\Images\\halloweenCandy2-small.jpg", "~\\Images\\halloweenCandy2.jpg", false, 5.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 13,
                columns: new[] { "CategoryId", "ImageThumbnailUrl", "ImageUrl", "IsOnSale", "Name", "Price" },
                values: new object[] { 4, "~\\Images\\halloweenCandy3-small.jpg", "~\\Images\\halloweenCandy3.jpg", true, "Assorted Halloween Candy", 6.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 14,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Price" },
                values: new object[] { "~\\Images\\hardCandy-small.jpg", "~\\Images\\hardCandy.jpg", true, false, 3.95m });

            migrationBuilder.UpdateData(
                table: "Candies",
                keyColumn: "CandyId",
                keyValue: 15,
                columns: new[] { "ImageThumbnailUrl", "ImageUrl", "IsInStock", "Price" },
                values: new object[] { "~\\Images\\hardCandy2-small.jpg", "~\\Images\\hardCandy2.jpg", false, 2.95m });

            migrationBuilder.InsertData(
                table: "Candies",
                columns: new[] { "CandyId", "CategoryId", "Description", "ImageThumbnailUrl", "ImageUrl", "IsInStock", "IsOnSale", "Name", "Price" },
                values: new object[] { 16, 5, " Lorem ipsum dolor sit amet, consectetur adiposcing elit, sed do eiusmod tempor...", "~\\Images\\hardCandy3-small.jpg", "~\\Images\\hardCandy3.jpg", true, true, "Assorted Hard Candy", 5.95m });
        }
    }
}

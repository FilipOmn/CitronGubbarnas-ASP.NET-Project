using Microsoft.EntityFrameworkCore.Migrations;

namespace Candyshop.Migrations
{
    public partial class AddednewtableCandyRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandyRating_Candies_CandyId",
                table: "CandyRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandyRating",
                table: "CandyRating");

            migrationBuilder.RenameTable(
                name: "CandyRating",
                newName: "CandyRatings");

            migrationBuilder.RenameIndex(
                name: "IX_CandyRating_CandyId",
                table: "CandyRatings",
                newName: "IX_CandyRatings_CandyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandyRatings",
                table: "CandyRatings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandyRatings_Candies_CandyId",
                table: "CandyRatings",
                column: "CandyId",
                principalTable: "Candies",
                principalColumn: "CandyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandyRatings_Candies_CandyId",
                table: "CandyRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandyRatings",
                table: "CandyRatings");

            migrationBuilder.RenameTable(
                name: "CandyRatings",
                newName: "CandyRating");

            migrationBuilder.RenameIndex(
                name: "IX_CandyRatings_CandyId",
                table: "CandyRating",
                newName: "IX_CandyRating_CandyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandyRating",
                table: "CandyRating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandyRating_Candies_CandyId",
                table: "CandyRating",
                column: "CandyId",
                principalTable: "Candies",
                principalColumn: "CandyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

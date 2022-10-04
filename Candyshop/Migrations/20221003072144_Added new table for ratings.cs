using Microsoft.EntityFrameworkCore.Migrations;

namespace Candyshop.Migrations
{
    public partial class Addednewtableforratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Candies");

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Candies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CandyRating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    CandyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandyRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandyRating_Candies_CandyId",
                        column: x => x.CandyId,
                        principalTable: "Candies",
                        principalColumn: "CandyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandyRating_CandyId",
                table: "CandyRating",
                column: "CandyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandyRating");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Candies");

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Candies",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

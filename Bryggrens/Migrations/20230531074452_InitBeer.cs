using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bryggrens.Migrations
{
    /// <inheritdoc />
    public partial class InitBeer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beer",
                columns: table => new
                {
                    ArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeerPrice = table.Column<decimal>(type: "money", nullable: true),
                    AlcoholPercent = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beer", x => x.ArticleNumber);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeerCategories",
                columns: table => new
                {
                    ArticleNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerCategories", x => new { x.ArticleNumber, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BeerCategories_Beer_ArticleNumber",
                        column: x => x.ArticleNumber,
                        principalTable: "Beer",
                        principalColumn: "ArticleNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeerCategories_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerCategories_CategoryId",
                table: "BeerCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerCategories");

            migrationBuilder.DropTable(
                name: "Beer");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

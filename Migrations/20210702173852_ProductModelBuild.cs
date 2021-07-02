using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcWeb.Migrations
{
    public partial class ProductModelBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    productNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    productName = table.Column<string>(type: "TEXT", nullable: false),
                    productDescription = table.Column<string>(type: "TEXT", nullable: true),
                    productUnit = table.Column<string>(type: "TEXT", nullable: false),
                    productPosition = table.Column<string>(type: "TEXT", nullable: true),
                    productPs = table.Column<string>(type: "TEXT", nullable: true),
                    productPicture = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateProduct_Category_Config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPropertyValuesInventories_Products_ProductId",
                table: "ProductPropertyValuesInventories");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPropertyValuesInventories_Products_ProductId",
                table: "ProductPropertyValuesInventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPropertyValuesInventories_Products_ProductId",
                table: "ProductPropertyValuesInventories");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPropertyValuesInventories_Products_ProductId",
                table: "ProductPropertyValuesInventories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

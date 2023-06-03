using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeLinkOneToMany_FromProductBuyItem_OnInventoryBuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyItems_Products_ProductId",
                table: "BuyItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "BuyItems",
                newName: "ProductPropertyValuesInventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_BuyItems_ProductId",
                table: "BuyItems",
                newName: "IX_BuyItems_ProductPropertyValuesInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyItems_ProductPropertyValuesInventories_ProductPropertyValuesInventoryId",
                table: "BuyItems",
                column: "ProductPropertyValuesInventoryId",
                principalTable: "ProductPropertyValuesInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyItems_ProductPropertyValuesInventories_ProductPropertyValuesInventoryId",
                table: "BuyItems");

            migrationBuilder.RenameColumn(
                name: "ProductPropertyValuesInventoryId",
                table: "BuyItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BuyItems_ProductPropertyValuesInventoryId",
                table: "BuyItems",
                newName: "IX_BuyItems_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyItems_Products_ProductId",
                table: "BuyItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

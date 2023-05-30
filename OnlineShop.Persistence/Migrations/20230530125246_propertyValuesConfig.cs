using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class propertyValuesConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPropertyValue_PropertyValues_PropertyValueId",
                table: "ProductPropertyValue");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPropertyValue_PropertyValues_PropertyValueId",
                table: "ProductPropertyValue",
                column: "PropertyValueId",
                principalTable: "PropertyValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPropertyValue_PropertyValues_PropertyValueId",
                table: "ProductPropertyValue");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPropertyValue_PropertyValues_PropertyValueId",
                table: "ProductPropertyValue",
                column: "PropertyValueId",
                principalTable: "PropertyValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class propertyValuesCongif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyValues_Properties_PropertyId",
                table: "PropertyValues");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyValues_Properties_PropertyId",
                table: "PropertyValues",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyValues_Properties_PropertyId",
                table: "PropertyValues");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyValues_Properties_PropertyId",
                table: "PropertyValues",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

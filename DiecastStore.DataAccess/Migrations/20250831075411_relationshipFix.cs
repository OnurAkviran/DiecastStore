using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiecastStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class relationshipFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_CarBrands_CategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CarBrandId",
                table: "Items",
                column: "CarBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_CarBrands_CarBrandId",
                table: "Items",
                column: "CarBrandId",
                principalTable: "CarBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_CarBrands_CarBrandId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CarBrandId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_CarBrands_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "CarBrands",
                principalColumn: "Id");
        }
    }
}
